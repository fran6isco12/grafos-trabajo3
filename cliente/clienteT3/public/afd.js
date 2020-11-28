window.onload = function () {

    var id = 0;
    var nestados=0;
    var finales = new Array();
    var inicial = 0;
    var tab = new Array();
    

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
                console.log(response);
            })
            .catch(function (error) {
                console.log("error");
                alert("Error");

            })
            .then(function () {
            });
    }
    function agretan() {
        if (document.getElementById("origen").value != null) {
            if (document.getElementById("destino").value != null) {
                if (document.getElementById("trancision").value != null) {
                    tab[(4 * document.getElementById("origen").value) + document.getElementById("destino").value] = document.getElementById("trancision").value;
                }
                else {
                    alert("transicion no valida");
                }

            }
            else {
                alert("destino no valido");
            }
        }
        else {
            alert("origen no valido");
        }

    }
    function addafd() {
        id = id + 1;
        nestados = document.getElementById("numes").value;
        console.log(document.getElementById("numes").value);
        console.log(nestados);
        for (var i = 0; i < nestados; i++) {
            tab.push("");
        }
        console.log(document.getElementById("numfn").value.length);
        var al = document.getElementById("numfn").value;
        console.log(al[i]);
        for (var i = 0; i < document.getElementById("numfn").value.length; i++); {
            console.log(document.getElementById("numfn").value[i]);
            if (document.getElementById("numfn").value[i] != "," && nestados >= document.getElementById("numfn").value[i]) {
                finales.push(document.getElementById("numfn").value[i]);

            }
            else {
                if (document.getElementById("numfn").value[i] != ",") {
                    alert(document.getElementById("numfn").value[i] + "no es un nodo valido");
                }
            }
        }
        console.log(finales);
        alert("estados agregados:" + finales);
    }
    function er() {
        postRequest;
        getByIdRequest;
    }
    document.getElementById("").onclick = addafd;
    document.getElementById("transicionbtn").onclick = agretan;
    document.getElementById("erbtn").onclick = er;


}
