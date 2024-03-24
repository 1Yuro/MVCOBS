function PasifHaleGetir(mufredatID) {
    fetch('/OgrElm/MufredatGuncelle?mufredatid=' + mufredatID, {
        method: 'POST',
    })
        .then(data => {

            location.reload();
        })
}
function MufredatDersEkle() {
    var selectedMufredatID = document.getElementById('mufredatsecimi').value;
    var selectedDersID = document.getElementById('derssecimi').value;
    var SelectedDonem = document.getElementById('donemsecimi').value;
    var postData = {
        mufredatID: selectedMufredatID,
        dersID: selectedDersID,
        DersDonem:SelectedDonem
    };
    fetch('/OgrElm/MufredatDersEkle', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(postData)
    })
        .then(data => {
            console.log(data);
            location.reload();
        })
}

document.addEventListener('DOMContentLoaded', function () {
    var ekleButtons = document.querySelectorAll('.btn-secondary');
    ekleButtons.forEach(function (button) {
        button.addEventListener('click', function () {
            var dersID = this.closest('.border').id;
            var secilecekDiv = document.getElementById(dersID);
            if (secilecekDiv) {
                secilecekDiv.remove();
                var eklenenButton = secilecekDiv.querySelector('.btn-secondary');
                if (eklenenButton) {
                    eklenenButton.remove();
                }

                document.getElementById('eklenecekdiv').appendChild(secilecekDiv);
            }
        });
    });
});
