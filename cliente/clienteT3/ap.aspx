﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ap.aspx.cs" Inherits="serviciot3.ap" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>GLF-T3</title>
</head>
<body runat="server">
    <div class="topnav">
        <a class="active" href="index.aspx">INICIO</a>
    </div>
    <div class="modal fade" id="myModal1" role="dialog">
        <div class="modal-dialog">

            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">AFND</h4>
                </div>
                <div class="modal-body">
                    <p>ya se ingresaron dos automatas para continuar elimine uno</p>
                    <p>Para continuar presione aceptar.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal" id="confirm1">eliminar 1</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal" id="confirm2">eliminar 2</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal" id="confirm3">cancelar</button>
                </div>
            </div>
        </div>
    </div>




    <div class="container">
        <div class="divL">
            <div class="container" id="container1">
                <div class="row">
                    <div><header class="heading"> AP</header></div>
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-xs-4">
                                <label class="numes">Num. estados :</label>
                            </div>
                            <div class="col-xs-8">
                                <input type="number" name="numes" id="numes" placeholder="ingrese el numero de estados" class="form-controlar">
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-xs-4">
                                <label class="numes">Num. trans.:</label>
                            </div>
                            <div class="col-xs-8">
                                <input type="number" name="numes" id="numts" placeholder="ingrese Nº de trans." class="form-controlar">

                            </div>
                            <div class="col-xs-4">

                                <input class="btn btn-primary" type="button" id="ingrdat" value="ingresar datos">

                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="row">
                            <input type="number" name="numes" id="apnum" placeholder="AP objetivo(ej:1)" class="form-controlar">
                        </div>

                    </div>

                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-xs-4">
                                <label class="numes">Estado Final :</label>
                            </div>
                            <div class="col-xs-8">
                                <input type="number" name="numes" id="numfn" placeholder="ingrese el EF(0 a n-1)" class="form-controlar">
                            </div>
                            <div class="col-xs-4">
                                <label class="numes">Alfabeto:</label>
                            </div>
                            <div class="col-xs-8">
                                <input type="text" name="numes" id="alfb" placeholder="agregar alfabeto (ej:E/E/E/a)" class="form-controlar">
                            </div>
                            <div class="col-xs-16">

                                <input class="btn btn-primary" type="button" id="agref" value="agregar EF">
                                <input class="btn btn-primary" type="button" id="agralf" value="agregar Alf">
                                <input class="btn btn-primary" type="button" id="agraap1" value="guardar AP1">
                                <input class="btn btn-primary" type="button" id="agraap2" value="guardar AP2">

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="divR">
            <div class="container" id="container2">
                <div class="row">
                    <div><header class="heading"></header></div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="row">
                                <input type="number" name="numes" id="apnum2" placeholder="AP objetivo(ej:1)" class="form-controlar">
                            </div>

                        </div>
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-xs-4">
                                    <label class="numes">Nodo origen: :</label>
                                </div>
                                <div class="col-xs-8">
                                    <input type="number" name="numes" id="origen" placeholder="Nodo origen(0 a n-1)" class="form-controlar">
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-xs-4">
                                    <label class="numes">Nodo destino :</label>
                                </div>
                                <div class="col-xs-8">
                                    <input type="number" name="numes" id="destino" placeholder="Nodo destino(0 a n-1)" class="form-controlar">
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-xs-4">
                                    <label class="numes">Trancision :</label>
                                </div>
                                <div class="col-xs-8">
                                    <input type="text" name="numes" id="trancision" placeholder="Transicion ej:0,1" class="form-controlar">
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-xs-12">
                                    <input class="btn btn-primary" type="button" id="transicionbtn" value="Nueva transicion">
                                    <input class="btn btn-primary" type="button" id="union" value="union">
                                    <input class="btn btn-primary" type="button" id="concatenacion" value="Concatenacion">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div><footer>GLFT3-2020S2</footer></div>
</body>
</html>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<link href="//netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
<link href="public/head.css" rel="stylesheet" />
<link href="public/afd.css" rel="stylesheet" />
<script src="https://unpkg.com/axios/dist/axios.min.js"></script>
<script src="public/ap.js"></script>