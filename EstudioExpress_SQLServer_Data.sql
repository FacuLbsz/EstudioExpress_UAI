USE[EstudioExpress]
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (3, N'hnkeEBj3FnsD5a/1QJeAvQ==', N'admin', N'admin', N'admin@mail.com', N'1A1DC91C907325C69271DDF0C944BC72',  1, N'E48FDED6437B5EA0EE723058D0F76DD0')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (4, N'm3DxqP3rImzVRT5P4u0uwQ==', N'Facundo', N'Vazquez', N'f@mail.com', N'1A1DC91C907325C69271DDF0C944BC72',  1, N'66BBA0EDA0ED6067C25723B6E831E7ED')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (5, N'buavlXCsgm+rIlJd6EKzXA==', N'Carlos', N'Sanchez', N'c@mail.com', N'1A1DC91C907325C69271DDF0C944BC72',  1, N'03CF833D95A3C453B601730DEE599743')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (6, N'30xiTR9zcAtlPIzL2pq2UQ==', N'Velo', N'Martelli', N'v@mail.com', N'1A1DC91C907325C69271DDF0C944BC72',  1, N'17F11B9B40A8AB174E9644D7D8698F03')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (7, N'RhPKr8BvAm5DOlTaVygreg==', N'Braian', N'Romero', N'b@mail.com', N'1A1DC91C907325C69271DDF0C944BC72',  1, N'ED53B54E5E86A3EE6F0C15703F9247A7')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (8, N'mm16CwFRejIYVgC98UfdaA==', N'Maxi', N'Meza', N'm@mail.com', N'1A1DC91C907325C69271DDF0C944BC72',  1, N'EBD28157EE2EF03F34AD8382008D2A57')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (9, N'HoyPzvXxk+B/a4+PaLak0Q==', N'Alan', N'Franco', N'a@mail.com', N'1A1DC91C907325C69271DDF0C944BC72',  1, N'F28EEB7C5D5B893582765266C2D8E32E')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (10, N'VIRCmBC1P50HIjTuQoWU8A==', N'Silvio', N'Romero', N's@mail.com', N'1A1DC91C907325C69271DDF0C944BC72',  1, N'05AC7F5AF8215FDFFDB23A0D1C0DD329')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (11, N'Y1kGcKzUF83vIrs9TfW7aQ==', N'Carlos', N'Tevez', N'ct@mail.com', N'1A1DC91C907325C69271DDF0C944BC72',  1, N'946A090603C266E042351E965972B448')
INSERT [dbo].[usuario] ([idUsuario], [nombreUsuario], [nombre], [apellido], [email], [contrasena], [habilitado], [digitoVerificadorH]) VALUES (12, N'hYo0IrNtZNkJzLuLKtcxtw==', N'Dario', N'Benedeto', N'd@mail.com', N'1A1DC91C907325C69271DDF0C944BC72',  1, N'2874B7998FB7A86E8756015CF0D7A8FE')
SET IDENTITY_INSERT [dbo].[usuario] OFF

SET IDENTITY_INSERT [dbo].[digitoverificadorvertical] ON 

INSERT [dbo].[digitoverificadorvertical] ([idDigitoVerificadorVertical], [tabla], [digitoVerificador]) VALUES (1, N'BITACORA', N'F4ECB8EC4D4433CCFC07CD0C65FDB774')
INSERT [dbo].[digitoverificadorvertical] ([idDigitoVerificadorVertical], [tabla], [digitoVerificador]) VALUES (2, N'USUARIO', N'2C4724405462C35D50B343140791E7E7')
INSERT [dbo].[digitoverificadorvertical] ([idDigitoVerificadorVertical], [tabla], [digitoVerificador]) VALUES (3, N'familiapatente', N'2C9E5EF388F1DC0FC7264D1CFC9C7322')
INSERT [dbo].[digitoverificadorvertical] ([idDigitoVerificadorVertical], [tabla], [digitoVerificador]) VALUES (4, N'PATENTEUSUARIO', N'A3385F532CA2D9E8CA2FC0B60F053479')
SET IDENTITY_INSERT [dbo].[digitoverificadorvertical] OFF
SET IDENTITY_INSERT [dbo].[familia] ON 

INSERT [dbo].[familia] ([idFamilia], [nombre], [habilitado]) VALUES (1, N'S/SMKX5LO5GGBoiPTVchIg==', 1)
INSERT [dbo].[familia] ([idFamilia], [nombre], [habilitado]) VALUES (2, N'S2EAyzryR4w0w+5YG3diAQ==', 1)
INSERT [dbo].[familia] ([idFamilia], [nombre], [habilitado]) VALUES (3, N'R3l5/+vqp3A+g4mvdpe5RQ==', 1)
SET IDENTITY_INSERT [dbo].[familia] OFF

SET IDENTITY_INSERT [dbo].[patente] ON 

INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (1, N'BITACORA')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (2, N'ADMINISRAR_CURSOS')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (3, N'CONSULTAR_CURSOS')
INSERT [dbo].[patente] ([idPatente], [nombre]) VALUES (4, N'MIS_CURSOS')
SET IDENTITY_INSERT [dbo].[patente] OFF

SET IDENTITY_INSERT [dbo].[familiapatente] ON 

INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (1, 1, 1, N'3C59DC048E8850243BE8079A5C74D079')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (2, 2, 2, N'3C59DC048E8850243BE8079A5C74D079')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (3, 3, 3, N'3C59DC048E8850243BE8079A5C74D079')
INSERT [dbo].[familiapatente] ([idFamiliaPatente], [Patente_idPatente], [Familia_idFamilia], [digitoVerificadorH]) VALUES (4, 4, 3, N'3C59DC048E8850243BE8079A5C74D079')
SET IDENTITY_INSERT [dbo].[familiapatente] OFF
SET IDENTITY_INSERT [dbo].[familiausuario] ON 

INSERT [dbo].[familiausuario] ([idFamiliaUsuario], [Familia_idFamilia], [Usuario_idUsuario]) VALUES (1, 1, 3)
INSERT [dbo].[familiausuario] ([idFamiliaUsuario], [Familia_idFamilia], [Usuario_idUsuario]) VALUES (2, 2, 4)
INSERT [dbo].[familiausuario] ([idFamiliaUsuario], [Familia_idFamilia], [Usuario_idUsuario]) VALUES (3,	3, 5)
SET IDENTITY_INSERT [dbo].[familiausuario] OFF


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