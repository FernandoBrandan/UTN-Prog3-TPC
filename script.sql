USE [TPCClinica]
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 12/10/2020 23:27:17 ******/
SET IDENTITY_INSERT [dbo].[Horario] ON
INSERT [dbo].[Horario] ([IdHorario], [Descripcion]) VALUES (1, N'1 a 2')
INSERT [dbo].[Horario] ([IdHorario], [Descripcion]) VALUES (2, N'2 a 3')
INSERT [dbo].[Horario] ([IdHorario], [Descripcion]) VALUES (3, N'3 a 4')
INSERT [dbo].[Horario] ([IdHorario], [Descripcion]) VALUES (4, N'4 a 5')
SET IDENTITY_INSERT [dbo].[Horario] OFF
/****** Object:  Table [dbo].[Especialidad]    Script Date: 12/10/2020 23:27:17 ******/
SET IDENTITY_INSERT [dbo].[Especialidad] ON
INSERT [dbo].[Especialidad] ([IdEspecialidad], [Nombre], [Descripcion], [Estado]) VALUES (7, N'Odontologo', N'Dientes', 1)
INSERT [dbo].[Especialidad] ([IdEspecialidad], [Nombre], [Descripcion], [Estado]) VALUES (8, N'Traumatologo', N'Te hizo la gamba crack', 1)
SET IDENTITY_INSERT [dbo].[Especialidad] OFF
/****** Object:  Table [dbo].[Seguridad]    Script Date: 12/10/2020 23:27:17 ******/
SET IDENTITY_INSERT [dbo].[Seguridad] ON
INSERT [dbo].[Seguridad] ([IdSeguridad], [Contraseña], [UltimaConexion]) VALUES (1, N'123', CAST(0xE8410B00 AS Date))
INSERT [dbo].[Seguridad] ([IdSeguridad], [Contraseña], [UltimaConexion]) VALUES (2, N'123', CAST(0xE8410B00 AS Date))
INSERT [dbo].[Seguridad] ([IdSeguridad], [Contraseña], [UltimaConexion]) VALUES (3, N'123', CAST(0xE8410B00 AS Date))
SET IDENTITY_INSERT [dbo].[Seguridad] OFF
/****** Object:  Table [dbo].[Persona]    Script Date: 12/10/2020 23:27:17 ******/
INSERT [dbo].[Persona] ([DNI], [Nombre], [Apellido], [Domicilio], [FechaNacimiento], [Genero], [Estado]) VALUES (111, N'Admin', N'Admin', N'Admin', CAST(0xAB410B00 AS Date), N'Masculino', 1)
INSERT [dbo].[Persona] ([DNI], [Nombre], [Apellido], [Domicilio], [FechaNacimiento], [Genero], [Estado]) VALUES (222, N'Medico', N'Medico', N'Medico', CAST(0xAB410B00 AS Date), N'Masculino', 1)
INSERT [dbo].[Persona] ([DNI], [Nombre], [Apellido], [Domicilio], [FechaNacimiento], [Genero], [Estado]) VALUES (333, N'Paciente', N'Paciente', N'Paciente', CAST(0xF3230B00 AS Date), N'Masculino', 1)
INSERT [dbo].[Persona] ([DNI], [Nombre], [Apellido], [Domicilio], [FechaNacimiento], [Genero], [Estado]) VALUES (38629407, N'Fer', N'Brandan', N'Porahi 123', CAST(0xB4230B00 AS Date), N'Femenino', 1)
/****** Object:  Table [dbo].[Perfil]    Script Date: 12/10/2020 23:27:17 ******/
SET IDENTITY_INSERT [dbo].[Perfil] ON
INSERT [dbo].[Perfil] ([IdPerfil], [Rol]) VALUES (1, N'Admin')
INSERT [dbo].[Perfil] ([IdPerfil], [Rol]) VALUES (2, N'Usuario')
INSERT [dbo].[Perfil] ([IdPerfil], [Rol]) VALUES (3, N'Medico')
SET IDENTITY_INSERT [dbo].[Perfil] OFF
/****** Object:  Table [dbo].[Paciente]    Script Date: 12/10/2020 23:27:17 ******/
INSERT [dbo].[Paciente] ([CodigoPaciente], [DNI], [FechaInscripcion], [Email]) VALUES (N'PacPac333', 333, CAST(0xE8410B00 AS Date), N'Paciente@gmail.com')
/****** Object:  Table [dbo].[Medico]    Script Date: 12/10/2020 23:27:17 ******/
INSERT [dbo].[Medico] ([LegajoMedico], [DNI], [FechaIngreso], [Especialidad], [Seguridad], [Perfil]) VALUES (N'MedMed222', 222, CAST(0xE8410B00 AS Date), 7, 2, 3)
/****** Object:  Table [dbo].[Disponibilidad]    Script Date: 12/10/2020 23:27:17 ******/
SET IDENTITY_INSERT [dbo].[Disponibilidad] ON
INSERT [dbo].[Disponibilidad] ([IdDisponibilidad], [Horario], [FechaTurno], [Estado]) VALUES (1, 1, CAST(0xF7410B00 AS Date), N'Activo')
INSERT [dbo].[Disponibilidad] ([IdDisponibilidad], [Horario], [FechaTurno], [Estado]) VALUES (2, 4, CAST(0xF7410B00 AS Date), N'Activo')
INSERT [dbo].[Disponibilidad] ([IdDisponibilidad], [Horario], [FechaTurno], [Estado]) VALUES (3, 2, CAST(0xEA410B00 AS Date), N'Activo')
INSERT [dbo].[Disponibilidad] ([IdDisponibilidad], [Horario], [FechaTurno], [Estado]) VALUES (4, 4, CAST(0xEF410B00 AS Date), N'Activo')
SET IDENTITY_INSERT [dbo].[Disponibilidad] OFF
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/10/2020 23:27:17 ******/
INSERT [dbo].[Usuario] ([LegajoUsuario], [DNI], [FechaIngreso], [Seguridad], [Perfil]) VALUES (N'Admin', 111, CAST(0xE8410B00 AS Date), 1, 1)
INSERT [dbo].[Usuario] ([LegajoUsuario], [DNI], [FechaIngreso], [Seguridad], [Perfil]) VALUES (N'FerBra386', 38629407, CAST(0xE8410B00 AS Date), 3, 2)
/****** Object:  Table [dbo].[Turno]    Script Date: 12/10/2020 23:27:17 ******/
SET IDENTITY_INSERT [dbo].[Turno] ON
INSERT [dbo].[Turno] ([IdTurno], [Disponibilidad], [Medico], [Paciente], [Motivo], [Estado]) VALUES (1, 1, N'MedMed222', N'PacPac333', N'Consulta', N'Atendido')
INSERT [dbo].[Turno] ([IdTurno], [Disponibilidad], [Medico], [Paciente], [Motivo], [Estado]) VALUES (11, 2, N'MedMed222', N'PacPac333', N'REQUERIDO', N'Cancelado')
INSERT [dbo].[Turno] ([IdTurno], [Disponibilidad], [Medico], [Paciente], [Motivo], [Estado]) VALUES (21, 3, N'MedMed222', N'PacPac333', N'muela', N'Pendiente')
INSERT [dbo].[Turno] ([IdTurno], [Disponibilidad], [Medico], [Paciente], [Motivo], [Estado]) VALUES (31, 4, N'MedMed222', N'PacPac333', N'no vino', N'Sin Atender')
SET IDENTITY_INSERT [dbo].[Turno] OFF
/****** Object:  Table [dbo].[FichaMedica]    Script Date: 12/10/2020 23:27:17 ******/
