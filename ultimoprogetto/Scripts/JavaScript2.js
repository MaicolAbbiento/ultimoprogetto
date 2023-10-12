$(document).ready(function () {
    $.ajax({
        method: 'GET',
        url: 'soldincassati',

        success: function (data) {
            console.log(data.numeroOrdiniEvasi, data.soldiDelgiorniorno)

            let p = `<p class="fs-1"> ${data.numeroOrdiniEvasi} <p>`

            $("#ciao").append(p)
            let p2 = `<p class="fs-1"> ${data.soldiDelgiorniorno} <p>`
            $("#ciaoi").append(p2)
        }
    })
})