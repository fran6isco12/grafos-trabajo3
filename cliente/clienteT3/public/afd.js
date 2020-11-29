window.onload = function () {
    var id = 0;
    var nestados=0;
    var finales = new Array();
    var inicial = 0;
    var tab = new Array();

    function getByIdRequest() {
        axios.get('http://localhost:52518/api/afd/' + id)
            .then(function (response) {
                document.getElementById("panel").innerHTML = response.data;
                console.log("ejecutado:" + id);
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
                "NEstados": parseInt(nestados),
                "EInicial": parseInt(inicial),
                "EFinales": finales,
                "tab": tab
            }

        })
            .then(function (response) {
                console.log(response);
                console.log("ejecutado:" + id)
            })
            .catch(function (error) {
                console.log("error");
                alert("Error");

            })
            .then(function () {
            });
    }
    function addfn() {
        var con = 0;
        console.log("res"+finales.indexOf(document.getElementById("numfn").value));
        if (document.getElementById("numfn").value < nestados) {
            for (var i = 0; i < finales.length; i++) {
                if (parseInt(document.getElementById("numfn").value)==finales[i]) {
                    con += 1;
                    console.log(con);
                }
            }
            if (con == 0) {
                finales.push(parseInt(document.getElementById("numfn").value));
                alert("estado final agregado");
                console.log(finales);
            }
            else {
                alert("estado final ya existe");
            }

        }
        else {
            alert("estado final fuera del rango");
            }
    }
    function agretan() {
        var origen = parseInt(document.getElementById("origen").value);
        var destino = parseInt(document.getElementById("destino").value);
        if (document.getElementById("origen").value != null && origen < nestados) {
            if (document.getElementById("destino").value != null && destino < nestados) {
                if (document.getElementById("trancision").value != null) {
                    tab[(nestados * origen) + destino] = document.getElementById("trancision").value;
                    alert("transicion agregada:" + tab[(nestados * origen) + destino]);
                    console.log(tab);
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
    function addaes() {
        id = id + 1;
        nestados = parseInt(document.getElementById("numes").value);
        console.log("es ingres"+document.getElementById("numes").value);
        console.log("es guardados" + nestados);
        for (var i = 0; i < nestados * nestados; i++) {
            tab.push("");
        }
        console.log(nestados);
        if (nestados != 0) {
            alert("numero de estados agregados:" + nestados)
        }
        else {
            alert("numero de estados invalido");
        }
        
    }

    document.getElementById("confirmau").onclick = addaes;
    document.getElementById("agrfin").onclick = addfn;
    document.getElementById("transicionbtn").onclick = agretan;
    document.getElementById("erbtn").onclick = postRequest;
    document.getElementById("confirm3").onclick = getByIdRequest;


}
