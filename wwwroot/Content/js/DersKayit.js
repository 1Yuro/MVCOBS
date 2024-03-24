//document.addEventListener('DOMContentLoaded', function () {
//    var toplamKredi = 0;
//    var ekleButtons = document.querySelectorAll('#DersAlmaEkrani button');

//    ekleButtons.forEach(function (button) {
//        button.addEventListener('click', function () {
//            var row = this.closest('tr');
//            var dersKodu = row.querySelector('td:nth-child(1)').textContent;
//            var dersAdi = row.querySelector('td:nth-child(2)').textContent;
//            var dersDili = row.querySelector('td:nth-child(3)').textContent;
//            var teorik = row.querySelector('td:nth-child(4)').textContent;
//            var uygulama = row.querySelector('td:nth-child(5)').textContent;
//            var kredi = row.querySelector('td:nth-child(6)').textContent;
//            var ects = row.querySelector('td:nth-child(7)').textContent;
//            if (toplamKredi + parseInt(kredi) > 30) {
//                alert('Maksimum 30 krediye ulaştınız. Daha fazla ders ekleyemezsiniz.');
//                return;
//            }
//            var secilenDerslerTablo = document.getElementById('secilenderslertablo').querySelector('tbody');
//            var newRow = secilenDerslerTablo.insertRow();
//            newRow.innerHTML = '<td>' + dersKodu + '</td>' +
//                '<td>' + dersAdi + '</td>' +
//                '<td>' + dersDili + '</td>' +
//                '<td>' + teorik + '</td>' +
//                '<td>' + uygulama + '</td>' +
//                '<td>' + kredi + '</td>' +
//                '<td>' + ects + '</td>';
//            toplamKredi += parseInt(kredi);
//            document.querySelector('#DersAlmadiv h4').textContent = 'Kredi: ' + toplamKredi;
//            row.remove();
//        });
//    });
//});

var toplamKredi = 0;

function ekleButtonClickHandler() {
    var row = this.closest('tr');
    var dersKodu = row.querySelector('td:nth-child(1)').textContent;
    var dersAdi = row.querySelector('td:nth-child(2)').textContent;
    var dersDili = row.querySelector('td:nth-child(3)').textContent;
    var teorik = row.querySelector('td:nth-child(4)').textContent;
    var uygulama = row.querySelector('td:nth-child(5)').textContent;
    var kredi = row.querySelector('td:nth-child(6)').textContent;
    var ects = row.querySelector('td:nth-child(7)').textContent;

    if (toplamKredi + parseInt(kredi) > 30) {
        alert('Maksimum 30 krediye ulaştınız. Daha fazla ders ekleyemezsiniz.');
        return;
    }

    var secilenDerslerTablo = document.getElementById('secilenderslertablo').querySelector('tbody');
    var newRow = secilenDerslerTablo.insertRow();
    newRow.innerHTML = '<td>' + dersKodu + '</td>' +
        '<td>' + dersAdi + '</td>' +
        '<td>' + dersDili + '</td>' +
        '<td>' + teorik + '</td>' +
        '<td>' + uygulama + '</td>' +
        '<td>' + kredi + '</td>' +
        '<td>' + ects + '</td>';

    toplamKredi += parseInt(kredi);
    document.querySelector('#DersAlmadiv h4').textContent = 'Kredi: ' + toplamKredi;
    row.remove();
}
var ekleButtons = document.querySelectorAll('#DersAlmaEkrani button');

ekleButtons.forEach(function (button) {
    button.addEventListener('click', ekleButtonClickHandler);
});
var kesinlestirButton = document.querySelector('#DersAlmaEkrani button.btn-secondary');

kesinlestirButton.addEventListener('click', function () {
    var secilenDerslerTablo = document.getElementById('secilenderslertablo').querySelectorAll('tbody tr');

    secilenDerslerTablo.forEach(function (row) {
        var dersKodu = row.querySelector('td:nth-child(1)').textContent;
        console.log(dersKodu);
        fetch('/Ogrenci/DersKayitKontrol', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ dersKodu: [dersKodu] }),
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                console.log(data);
                if (data.success) {
                    alert(data.message);
                } else {
                    alert(data.message);
                }
            })
            .catch(error => {
                console.error('Hata:', error);
            });
    });
});
