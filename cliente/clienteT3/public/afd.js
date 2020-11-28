window.onload = function () {

    var id = 0;
    var nestados = 4;
    var finales = new Array();
    var inicial = 0;


    var tab = ["0,1", "1", "", "", "", "", "0,1", "", "", "", "", "0,1", "", "", "", ""];

        finales.push(2);
    finales.push(3);
    function getByIdRequest() {

        axios.get('http://localhost:52518/api/afd/' + "0")
            .then(function (response) {
                document.getElementById("panel").innerHTML = response.data;
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
                alert("Error");
            })
            .then(function () {
            });
    }
    function postRequest() {
        axios({
            method: "post",
            url: "http://localhost:52518/api/afd/agregar",
            headers: {
                "Content-Type": "application/json"
            },
            data: {
                "Id": id,
                "NEstados": nestados,
                "EInicial": inicial,
                "EFinales": finales,
                "tab": tab
            }

        })
            .then(function (response) {
                document.getElementById("saludo").innerHTML = response.data.mensaje;
                console.log(response);
            })
            .catch(function (error) {
                console.log("error");
                alert("Error");

            })
            .then(function () {
            });
    }

    function addafd() {
        id = id + 1;
        nestados = document.getElementById("numes").value;
        for (var i = 0; i < document.getElementById("numfn").value.length; i++);
        if (document.getElementById("numfn").value[i] <= nestados) {
            finales.push(document.getElementById("numfn").value[i]);
        }
        else {
            alert(document.getElementById("numfn").value[i] + "no es un nodo valido");
        }
        alert("estados agregados:" + JSON.tostringfy(finales));
    }
    document.getElementById("transicionbtn").onclick = getByIdRequest;
    document.getElementById("erbtn").onclick = postRequest;


}
