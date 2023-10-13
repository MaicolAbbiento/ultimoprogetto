$(document).ready(function () {
    $.ajax({
        method: 'GET',
        url: 'query2',
        success: function (data) {
            console.log(data)
            $.each(data, function (n, e) {
                console.log(data)
                let input1 = `<input type="number" id="inp${e}" placeholder="inseire la quantità" />
        <input type="button" class="btn btnb" id="btn${e}" value="ordina" />`
                $(`#${e}`).append(input1)
                $(`#btn${e}`).click(function () {
                    let impt = $(`#inp${e}`).val();

                    $.ajax({
                        method: 'POST',
                        url: 'ordina',
                        data: { input: impt, id: e },
                        success: function (data) {
                        }
                    })
                })
            })
        }
    })
})