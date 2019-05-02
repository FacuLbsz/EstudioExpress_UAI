USE[EstudioExpress]
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (3, N'hnkeEBj3FnsD5a/1QJeAvQ==', N'admin', N'admin', N'admin@mail.com', N'9C7ACD47D05ABC324D55D5AD3E01D005',  1, N'E48FDED6437B5EA0EE723058D0F76DD0')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (4, N'm3DxqP3rImzVRT5P4u0uwQ==', N'Facundo', N'Vazquez', N'f@mail.com', N'9C7ACD47D05ABC324D55D5AD3E01D005',  1, N'66BBA0EDA0ED6067C25723B6E831E7ED')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (5, N'buavlXCsgm+rIlJd6EKzXA==', N'Carlos', N'Sanchez', N'c@mail.com', N'9C7ACD47D05ABC324D55D5AD3E01D005',  1, N'03CF833D95A3C453B601730DEE599743')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (6, N'30xiTR9zcAtlPIzL2pq2UQ==', N'Velo', N'Martelli', N'v@mail.com', N'9C7ACD47D05ABC324D55D5AD3E01D005',  1, N'17F11B9B40A8AB174E9644D7D8698F03')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (7, N'RhPKr8BvAm5DOlTaVygreg==', N'Braian', N'Romero', N'b@mail.com', N'9C7ACD47D05ABC324D55D5AD3E01D005',  1, N'ED53B54E5E86A3EE6F0C15703F9247A7')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (8, N'mm16CwFRejIYVgC98UfdaA==', N'Maxi', N'Meza', N'm@mail.com', N'9C7ACD47D05ABC324D55D5AD3E01D005',  1, N'EBD28157EE2EF03F34AD8382008D2A57')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (9, N'HoyPzvXxk+B/a4+PaLak0Q==', N'Alan', N'Franco', N'a@mail.com', N'9C7ACD47D05ABC324D55D5AD3E01D005',  1, N'F28EEB7C5D5B893582765266C2D8E32E')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (10, N'VIRCmBC1P50HIjTuQoWU8A==', N'Silvio', N'Romero', N's@mail.com', N'9C7ACD47D05ABC324D55D5AD3E01D005',  1, N'05AC7F5AF8215FDFFDB23A0D1C0DD329')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (11, N'Y1kGcKzUF83vIrs9TfW7aQ==', N'Carlos', N'Tevez', N'ct@mail.com', N'9C7ACD47D05ABC324D55D5AD3E01D005',  1, N'946A090603C266E042351E965972B448')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (12, N'hYo0IrNtZNkJzLuLKtcxtw==', N'Dario', N'Benedeto', N'd@mail.com', N'9C7ACD47D05ABC324D55D5AD3E01D005',  1, N'2874B7998FB7A86E8756015CF0D7A8FE')
SET IDENTITY_INSERT [dbo].[usuario] OFF

SET IDENTITY_INSERT [dbo].[digitoverificadorvertical] ON 

INSERT [dbo].[digitoverificadorvertical] ([idDigitoVerificadorVertical], [tabla], [digitoVerificador]) VALUES (1, N'BITACORA', N'F4ECB8EC4D4433CCFC07CD0C65FDB774')
INSERT [dbo].[digitoverificadorvertical] ([idDigitoVerificadorVertical], [tabla], [digitoVerificador]) VALUES (2, N'USUARIO', N'2C4724405462C35D50B343140791E7E7')
INSERT [dbo].[digitoverificadorvertical] ([idDigitoVerificadorVertical], [tabla], [digitoVerificador]) VALUES (3, N'familiapatente', N'2C9E5EF388F1DC0FC7264D1CFC9C7322')
INSERT [dbo].[digitoverificadorvertical] ([idDigitoVerificadorVertical], [tabla], [digitoVerificador]) VALUES (4, N'PATENTEUSUARIO', N'A3385F532CA2D9E8CA2FC0B60F053479')
SET IDENTITY_INSERT [dbo].[digitoverificadorvertical] OFF
SET IDENTITY_INSERT [dbo].[familia] ON 

INSERT [dbo].[familia] ([idFamilia], [nombre], [habilitado]) VALUES (1, N'Gzrqcn0yM9BMAD1YuT9AaQ==', 1)
INSERT [dbo].[familia] ([idFamilia], [nombre], [habilitado]) VALUES (2, N'LP60jnk2hJ7ABj0q/2mVww==', 1)
INSERT [dbo].[familia] ([idFamilia], [nombre], [habilitado]) VALUES (3, N'+Uqtwn/q0zArrc86oPPP4Q==', 1)
INSERT [dbo].[familia] ([idFamilia], [nombre], [habilitado]) VALUES (5, N'b/yNC5uVFbmc/ABLzN0rRg==', 1)
SET IDENTITY_INSERT [dbo].[familia] OFF

SET IDENTITY_INSERT [dbo].[patente] ON 

INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (1, N'MI_ESTADO')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (2, N'EVALUAR_EQUIPOS_A_CARGO')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (3, N'REPORTE_OBJETIVOS_POR_EMPLEADO')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (4, N'REPORTE_OBJETIVOS_POR_EQUIPO')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (5, N'REPORTE_BENEFICIO_POR_EMPLEADO')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (12, N'BITACORA')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (13, N'BACKUP')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (14, N'RESTORE')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (15, N'ADMINISTRACION_USUARIOS_CREACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (16, N'ADMINISTRACION_USUARIOS_MODIFICACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (17, N'ADMINISTRACION_USUARIOS_ELIMINACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (18, N'ADMINISTRACION_FAMILIAS_CREACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (19, N'ADMINISTRACION_FAMILIAS_MODIFICACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (20, N'ADMINISTRACION_FAMILIAS_ELIMINACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (21, N'ADMINISTRACION_GRUPOS_CREACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (22, N'ADMINISTRACION_GRUPOS_MODIFICACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (23, N'ADMINISTRACION_GRUPOS_ELIMINACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (24, N'ADMINISTRACION_EQUIPOS_CREACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (25, N'ADMINSITRACION_EQUIPOS_MODIFICACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (26, N'ADMINISTRACION_EQUIPOS_ELIMINACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (27, N'ADMINISTRACION_BENEFICIOS_CREACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (28, N'ADMINISTRACION_BENEFICIOS_MODIFICACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (29, N'ADMINISTRACION_BENEFICIOS_ELIMINACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (30, N'ADMINISTRACION_OBJETIVOS_CREACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (31, N'ADMINISTRACION_OBJETIVOS_MODIFICACION')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (32, N'ADMINISTRACION_OBJETIVOS_ELIMINACION')
SET IDENTITY_INSERT [dbo].[patente] OFF

SET IDENTITY_INSERT [dbo].[familiapatente] ON 

INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (1, 2, 1, N'3C59DC048E8850243BE8079A5C74D079')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (2, 3, 1, N'C16A5320FA475530D9583C34FD356EF5')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (3, 4, 1, N'3416A75F4CEA9109507CACD8E2F2AEFC')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (4, 5, 1, N'2838023A778DFAECDC212708F721B788')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (5, 21, 1, N'EB163727917CBBA1EEA208541A643E74')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (6, 22, 1, N'060AD92489947D410D897474079C1477')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (7, 23, 1, N'9B04D152845EC0A378394003C96DA594')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (8, 24, 1, N'F340F1B1F65B6DF5B5E3F94D95B11DAF')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (9, 25, 1, N'19F3CD308F1455B3FA09A282E0D496F4')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (10, 26, 1, N'B1A59B315FC9A3002CE38BBE070EC3F5')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (11, 27, 1, N'7F100B7B36092FB9B06DFB4FAC360931')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (12, 28, 1, N'E3796AE838835DA0B6F6EA37BCF8BCB7')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (13, 29, 1, N'9C838D2E45B2AD1094D42F4EF36764F6')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (14, 30, 1, N'34ED066DF378EFACC9B924EC161E7639')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (15, 31, 1, N'9DFCD5E558DFA04AAF37F137A1D9D3E5')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (16, 32, 1, N'CAF1A3DFB505FFED0D024130F58C5CFA')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (17, 1, 2, N'C20AD4D76FE97759AA27A0C99BFF6710')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (18, 2, 3, N'37693CFC748049E45D87B8C7D8B9AACD')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (19, 3, 3, N'182BE0C5CDCD5072BB1864CDEE4D3D6E')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (20, 4, 3, N'17E62166FC8586DFA4D1BC0E1742C08B')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (21, 5, 3, N'D82C8D1619AD8176D665453CFB2E55F0')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (56, 12, 5, N'3DEF184AD8F4755FF269862EA77393DD')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (57, 13, 5, N'7F1DE29E6DA19D22B51C68001E7E0E54')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (58, 14, 5, N'2B24D495052A8CE66358EB576B8912C8')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (59, 15, 5, N'2A79EA27C279E471F4D180B08D62B00A')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (61, 17, 5, N'82161242827B703E6ACF9C726942A1E4')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (62, 16, 5, N'9766527F2B5D3E95D4A733FCFB77BD7E')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (63, 18, 5, N'EECCA5B6365D9607EE5A9D336962C534')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (64, 19, 5, N'0336DCBAB05B9D5AD24F4333C7658A0E')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (65, 20, 5, N'EAE27D77CA20DB309E056E3D2DCD7D69')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (75, 12, 5, N'3DEF184AD8F4755FF269862EA77393DD')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (76, 13, 5, N'7F1DE29E6DA19D22B51C68001E7E0E54')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (77, 14, 5, N'2B24D495052A8CE66358EB576B8912C8')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (78, 15, 5, N'2A79EA27C279E471F4D180B08D62B00A')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (79, 17, 5, N'82161242827B703E6ACF9C726942A1E4')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (80, 16, 5, N'9766527F2B5D3E95D4A733FCFB77BD7E')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (81, 18, 5, N'EECCA5B6365D9607EE5A9D336962C534')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (82, 19, 5, N'0336DCBAB05B9D5AD24F4333C7658A0E')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (83, 20, 5, N'EAE27D77CA20DB309E056E3D2DCD7D69')
SET IDENTITY_INSERT [dbo].[familiapatente] OFF
SET IDENTITY_INSERT [dbo].[familiausuario] ON 

INSERT [dbo].[familiausuario] ([idFamiliaUsuario], [Familia_idFamilia], [Usuario_idUsuario]) VALUES (1, 1, 4)
INSERT [dbo].[familiausuario] ([idFamiliaUsuario], [Familia_idFamilia], [Usuario_idUsuario]) VALUES (2, 3, 11)
INSERT [dbo].[familiausuario] ([idFamiliaUsuario], [Familia_idFamilia], [Usuario_idUsuario]) VALUES (3, 2, 12)
INSERT [dbo].[familiausuario] ([idFamiliaUsuario], [Familia_idFamilia], [Usuario_idUsuario]) VALUES (4, 2, 9)
INSERT [dbo].[familiausuario] ([idFamiliaUsuario], [Familia_idFamilia], [Usuario_idUsuario]) VALUES (5, 2, 6)
INSERT [dbo].[familiausuario] ([idFamiliaUsuario], [Familia_idFamilia], [Usuario_idUsuario]) VALUES (7, 5, 3)
SET IDENTITY_INSERT [dbo].[familiausuario] OFF

SET IDENTITY_INSERT [dbo].[patenteusuario] ON 

INSERT [dbo].[patenteusuario] ([idPatente], [esPermisiva], [Patente_idPatente], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (1, 0, 12, 3, N'EB62F6B9306DB575C2D596B1279627A4')
SET IDENTITY_INSERT [dbo].[patenteusuario] OFF

SET IDENTITY_INSERT [dbo].[bitacora] ON 

INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (2, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-07T01:28:49.000' AS DateTime), N'LOGIN', 3, N'F5C9C14DE1AC278964690A614F020997')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (3, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-07T01:29:14.000' AS DateTime), N'LOGIN', 3, N'70A470591E454263FBA6DA4F1125756C')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (4, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-08T04:23:47.000' AS DateTime), N'LOGIN', 3, N'9CB953F1EDAE045F5CCFAEA7E495B9B1')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (5, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-08T04:53:41.000' AS DateTime), N'LOGIN', 3, N'BF8FC118FF928FA91CC451AB41B5D81A')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (6, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-08T05:15:43.000' AS DateTime), N'LOGIN', 3, N'96281C86CD6EB2090D8775A9E222BF85')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (7, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-10T16:16:13.000' AS DateTime), N'LOGIN', 3, N'C2E56FEFBF58FCB038DA120F3BBB273C')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (8, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-10T16:16:57.000' AS DateTime), N'LOGIN', 3, N'CA1D550EE2AD060A7C5816A335A565F3')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (9, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-10T16:17:45.000' AS DateTime), N'LOGIN', 3, N'51C912242C50EF3E4A2D2015A9B185BC')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (10, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-10T17:47:36.000' AS DateTime), N'LOGIN', 3, N'0F1A3D05265B273BCA3A32C6A4F78C69')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (11, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T14:49:48.000' AS DateTime), N'LOGIN', 3, N'0EAC9DB6C9F21A16D05CBD66326A088C')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (12, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T15:19:07.000' AS DateTime), N'LOGIN', 3, N'9F56709C82BCCCF7C7782673BA295461')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (13, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T15:21:18.000' AS DateTime), N'LOGIN', 3, N'B879F3889DCD736078F3E275C5803C58')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (14, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T15:28:21.000' AS DateTime), N'LOGIN', 3, N'52E7A25DB699FBE37133E59934BCE45A')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (15, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T15:31:56.000' AS DateTime), N'LOGIN', 3, N'61CAC0DD255C077DD0FFECECCDA9AA07')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (16, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T16:15:33.000' AS DateTime), N'LOGIN', 3, N'CBC76F1C8D173430DD794C862EA83E8A')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (17, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T16:49:14.000' AS DateTime), N'LOGIN', 3, N'A4ADDE6580604BD501B372BFFC56AD70')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (18, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T16:51:56.000' AS DateTime), N'LOGIN', 3, N'7CEF654CA0E20870E8084D3191697234')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (19, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T16:57:10.000' AS DateTime), N'LOGIN', 3, N'F926ACF6DBAAEA3C896C7BF1F1DCF9FE')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (20, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T16:58:29.000' AS DateTime), N'LOGIN', 3, N'325B911F7CB6F56B368AE064E8E2044B')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (21, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T17:01:53.000' AS DateTime), N'LOGIN', 3, N'E05EA985B71A169ADF11784162DB03E0')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (22, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T17:09:58.000' AS DateTime), N'LOGIN', 3, N'AC1C4DCB8A1A7B79A63302042300C662')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (23, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T17:41:53.000' AS DateTime), N'LOGIN', 3, N'3E721704C21716035F40C2B6AFBA9A6F')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (24, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T17:45:10.000' AS DateTime), N'LOGIN', 3, N'07E5862C55EC9E52A30EFA1BD05E54AB')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (25, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T18:02:16.000' AS DateTime), N'LOGIN', 3, N'25219A252874BA1076B67DF088B3AA88')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (26, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T23:04:38.000' AS DateTime), N'LOGIN', 3, N'AB2F70293C14B4891C06E83A133208B3')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (27, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T23:05:38.000' AS DateTime), N'LOGIN', 3, N'AF4A2863FCB9935970A67A3F7AE7F8F9')
INSERT [dbo].[bitacora] ([idBitacora], [criticidad], [descripcion], [fecha], [funcionalidad], [Usuario_idUsuario], [digitoVerificadorH]) VALUES (28, 2, N'4TXB7mxNQ48Yep2crakneQ==', CAST(N'2018-11-11T23:11:47.000' AS DateTime), N'LOGIN', 3, N'D50B6CA85681A635D010C19A6C777C04')
SET IDENTITY_INSERT [dbo].[bitacora] OFF