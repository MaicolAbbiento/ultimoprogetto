$(document).ready(function () {
    $.ajax({
        method: 'GET',
        url: 'query2',
        success: function (data) {
            $.each(data, function (n, e) {
                let input1 = `<input type="number" id="inp${e.idpizza}" placeholder="inseire la quantità" />
        <input type="button" id="btn${e.idpizza}" value="ordina" />`
                $(`#${e.idpizza}`).append(input1)
                $(`#btn${e.idpizza}`).click(function () {
                    let impt = $(`#inp${e.idpizza}`).val();
                    $.ajax({
                        method: 'POST',
                        url: 'ordina',
                        data: { input: impt },
                        success: function (data) {
                            Session["pizza"] = data
                        }
                    })
                })
            })
        }
    })
})