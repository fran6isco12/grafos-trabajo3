window.onload = function () {
    var id1 = 1;
    var id2 = 2;
    var idtr;
    var alf = new Array();
    var nes;
    var con = 0;
    var ntr;
    var tab = new Array();
    var fin = new Array();
    var nes2;
    var con2 = 0;
    var ntr2;
    var alf2 = new Array();
    var tab2 = new Array();
    var fin2 = new Array();
    var cons;
    var inicial = 0;
    var accion;
    var tr;
    var origen;
    var destino;
    function adddat() {
        if (con == 0) {
            if (document.getElementById("numes").value != 0) {
                if (document.getElementById("numts") != 0) {
                    nes = parseInt(document.getElementById("numes").value);
                    console.log("nes ingrensado:" + nes);
                    ntr = parseInt(document.getElementById("numts").value);
                    console.log(console.log("ntr ingrensado:" + ntr));
                    alert("datos agregados")
                }
                else {
                    alert("numero de transiciones invalido");
                    console.log("numtrans:" + document.getElementById("numts"));
                }
            }
            else {
                alert("numero de estados invalido");
                console.log("numesta:" + document.getElementById("numes").value)
                con = 1;
            }
        }
        else {
            if (con2 == 0) {
                if (document.getElementById("numes").value != 0) {
                    if (document.getElementById("numts") != 0) {
                        nes2 = parseInt(document.getElementById("numes").value);
                        console.log("nes ingrensado:" + nes2);
                        ntr2 = parseInt(document.getElementById("numts").value);
                        console.log(console.log("ntr ingrensado:" + ntr2));
                        alert("datos agregados")
                    }
                    else {
                        alert("numero de transiciones invalido");
                        console("numtrans:" + document.getElementById("numts"));
                    }
                }
                else {
                    alert("numero de estados invalido");
                    console("numesta:" + document.getElementById("numes").value)
                    con2 = 1;
                }
            }
        }
    }


    function addfn() {
        if (document.getElementById("apnum").value == id1) {
            cons = 0;
            if (parseInt(document.getElementById("numfn").value) < nes) {
                for (var i = 0; i < fin.length; i++) {
                    if (parseInt(document.getElementById("numfn").value) == fin[i]) {
                        cons += 1;
                        console.log(cons);
                    }
                }
                if (cons == 0) {
                    fin.push(parseInt(document.getElementById("numfn").value));
                    console.log("finales:" + fin);
                    alert("estado final agregado");
                }
                else {
                    alert("estado final ya existe");
                }
            }
            else {
                alert("estado fuera de rango");
            }
        }
        else {
            if (document.getElementById("apnum").value == id2) {
                cons = 0;
                if (parseInt(document.getElementById("numfn").value) < nes2) {
                    for (var i = 0; i < fin2.length; i++) {
                        if (parseInt(document.getElementById("numfn").value) == fin2[i]) {
                            cons += 1;
                            console.log(cons);
                        }
                    }
                    if (cons == 0) {
                        fin2.push(parseInt(document.getElementById("numfn").value));
                        console.log("finales:" + fin2);
                        alert("estado final agregado");
                    }
                    else {
                        alert("estado final ya existe");
                    }
                }
                else {
                    alert("estado fuera de rango");
                }
            }
            else {
                alert("ap destino no valido");
            }
        }
    }

    function addalf() {
        if (document.getElementById("apnum").value == id1) {
            if (document.getElementById("alfb").value != null) {
                alf.push(document.getElementById("alfb").value);
                alert("alfabeto agregado");
                console.log("alfab:" + alf);
            }
            else {
                alert("alfabeto no valido");
            }
        }
        else {
            if (document.getElementById("apnum").value == id2) {
                if (document.getElementById("alfb").value != null) {
                    alf2.push(document.getElementById("alfb").value);
                    alert("alfabeto agregado");
                    console.log("alfab:" + alf2);
                }
                else {
                    alert("alfabeto no valido");
                }
            }
            else {
                alert("ap destino no valido");
            }
        }
    }

    function addd(){
        if (con == 0) {
            adddat();
        }
        else {
            if (con2 == 0) {
                adddat();
            }
            else {
                $('#modal1').modal('show');
            }
        }

    }

    function eliminar() {
        alf = new Array();
        nes=0;
        con = 0;
        ntr=0;
        tab = new Array();
        fin = new Array();
    }
    function eliminar2() {
        alf2 = new Array();
        nes2 = 0;
        con2 = 0;
        ntr2 = 0;
        tab2 = new Array();
        fin2 = new Array();
    }
    function postRequest() {
        axios({
            method: "post",
            url: "http://localhost:4141/api/ap/agregar",
            headers: {
                "Content-Type": "application/json"
            },
            data: {
                "Id": id1,
                "numEstados": parseInt(nes),
                "estadoInicial": parseInt(inicial),
                "totalTransiciones": parseInt(ntr),
                "alfabt": alf,
                "finales": fin
            }

        })
            .then(function (response) {
                console.log(response);
                console.log("ejecutado:" + id1)
                alert("guardado");
            })
            .catch(function (error) {
                console.log("error");
                alert("Error");

            })
            .then(function () {
            });
    }
    function postRequest2() {
        axios({
            method: "post",
            url: "http://localhost:4141/api/ap/agregar",
            headers: {
                "Content-Type": "application/json"
            },
            data: {
                "Id": id2,
                "numEstados": parseInt(nes2),
                "estadoInicial": parseInt(inicial),
                "totalTransiciones": parseInt(ntr2),
                "alfabt": alf,
                "finales": fin2
            }

        })
            .then(function (response) {
                alert("guardado");
                console.log(response);
                console.log("ejecutado:" + id2)
            })
            .catch(function (error) {
                console.log("error");
                alert("Error");

            })
            .then(function () {
            });
    }
    function postRequest3() {
        axios({
            method: "post",
            url: "http://localhost:4141/api/ap/agregartr",
            headers: {
                "Content-Type": "application/json"
            },
            data: {
                "Id": idr,
                "origen": origen,
                "destino": destino,
                "trans": tr
            }

        })
            .then(function (response) {
                alert("trancison agregada")
                console.log(response);
                console.log("ejecutado:" + id2)
            })
            .catch(function (error) {
                console.log("error");
                alert("Error");

            })
            .then(function () {
            });
    }
    function addtr() {
        if (document.getElementById("apnum2").value == id1) {
            idtr = id1;
            if (parseInt(document.getElementById("origen").value) < nes) {
                origen = parseInt(document.getElementById("origen").value);
                if (parseInt(document.getElementById("destino").value) < nes) {
                    destino = parseInt(document.getElementById("destino").value);
                    if (document.getElementById("trancision").value != null) {
                        tr = document.getElementById("trancision").value;
                        postRequest3();
                    }
                    else {
                        alert("trancision no valida")
                    }
                }
                else {
                    alert("destino no valido");
                }
            }
            else {
                alert("origen no valido")
            }
        }
        else {
            if (document.getElementById("apnum2").value ==  id12) {
                idtr = id2;
                if (parseInt(document.getElementById("origen").value) < nes2) {
                    origen = parseInt(document.getElementById("origen").value);
                    if (parseInt(document.getElementById("destino").value) < nes2) {
                        destino = parseInt(document.getElementById("destino").value);
                        if (document.getElementById("trancision").value != null) {
                            tr = document.getElementById("trancision").value;
                            postRequest3();
                        }
                        else {
                            alert("trancision no valida")
                        }
                    }
                    else {
                        alert("destino no valido");
                    }
                }
                else {
                    alert("origen no valido")
                }
            }
            else {
                alert("ap no valido")
            }
        }
    }
    function getByIdRequest() {
        axios.get('http://localhost:4141/api/ap/union/' + accion)
            .then(function (response) {
                if (accion == 1) { alert("la union es: \n" + response.data); }
                if (accion == 2) { alert("la conacatenacion es: \n" + response.data); }
                console.log("ejecutado:" + accion);
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
                alert("Error");
            })
            .then(function () {
            });
    }

    function union() {
        accion = 1;
        getByIdRequest();
    }
    function concatenacion() {
        accion = 2;
        getByIdRequest();
    }
    document.getElementById("ingrdat").onclick = addd;
    document.getElementById("confirm1").onclick = eliminar;
    document.getElementById("confirm2").onclick = eliminar2;
    document.getElementById("union").onclick = union;
    document.getElementById("concatenacion").onclick = concatenacion;
    document.getElementById("transicionbtn").onclick = addtr;
    document.getElementById("agraap1").onclick = postRequest;
    document.getElementById("agraap2").onclick = postRequest2;
    document.getElementById("agref").onclick = addfn;
    document.getElementById("agralf").onclick = addalf;
}
