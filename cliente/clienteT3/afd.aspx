﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="afd.aspx.cs" Inherits="serviciot3.afd" %>

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
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">

            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">AFND</h4>
                </div>
                <div class="modal-body">
                    <p>Esta accion eliminara todos los datos ya ingresados.</p>
                    <p>Para continuar presione aceptar.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal" id="confirm">Aceptar</button>
                </div>
            </div>


        </div>
    </div>

    <div class="modal fade" id="myModal2" role="dialog">
        <div class="modal-dialog">

            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">AFND</h4>
                </div>
                <div class="modal-body">
                    <p>Esta accion eliminara las trancisiones.</p>
                    <p>Para continuar presione aceptar.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal" id="confirmau">Aceptar</button>
                </div>
            </div>


        </div>
    </div>

    <div class="modal fade" id="myModal3" role="dialog">
        <div class="modal-dialog">

            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">AFND</h4>
                </div>
                <div class="modal-body">
                    <p>automata ingresado expresion regular en proceso.</p>
                    <p>Para continuar presione aceptar.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal" id="confirm3">Aceptar</button>
                </div>
            </div>


        </div>
    </div>

    <div class="container">
        <div class="divL">
            <div class="container" id="container1">
                <div class="row">
                    <div><header class="heading"> AFND</header></div>
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-xs-4">
                                <label class="numes">Num. estados :</label>
                            </div>
                            <div class="col-xs-8">
                                <input type="number" name="numes" id="numes" placeholder="ingrese el numero de estados" class="form-control ">
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-xs-4">
                                <label class="numes">Estados finales :</label>
                            </div>
                            <div class="col-xs-8">
                                <input type="number" name="numes" id="numfn" placeholder="ingrese el EF(0 a n-1)" class="form-control ">
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-xs-8">
                                <input class="btn btn-primary" type="button" id="agres" value="ingresar NumE" data-toggle="modal" data-target="#myModal2">
                                <input class="btn btn-primary" type="button" id="agrfin" value="Ingresar EF">

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
                                <div class="col-xs-4">
                                    <label class="numes">Nodo origen: :</label>
                                </div>
                                <div class="col-xs-8">
                                    <input type="text" name="numes" id="origen" placeholder="Nodo origen(0 a n-1)" class="form-controlar">
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-xs-4">
                                    <label class="numes">Nodo destino :</label>
                                </div>
                                <div class="col-xs-8">
                                    <input type="text" name="numes" id="destino" placeholder="Nodo destino(0 a n-1)" class="form-controlar">
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
                                <div class="col-xs-4">
                                    <input class="btn btn-primary" type="button" id="transicionbtn" value="Nueva transicion">
                                </div>
                                <div class="col-xs-8">
                                    <input class="btn btn-primary" type="button" id="erbtn" value="Expresion R."data-toggle="modal" data-target="#myModal3">
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">

                            <div class="panel panel-default">
                                <div class="panel-body" id="panel">Expresion Regular</div>
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
<script src="public/afd.js"></script>
<script src="https://unpkg.com/axios/dist/axios.min.js"></script>