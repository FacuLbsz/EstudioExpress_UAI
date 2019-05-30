# Estudio Express UAI

Para iniciar este proyecto se deben realizar los siguientes pasos:

### Configurar Base de datos SQL
Correr los siguientes dos scripts:
EstudioExpress_SQLServer_Scheme.sql
EstudioExpress_SQLServer_Data.sql

### Modificar String de conexion
Modificar en el archivo \EstudioExpress_DAL\BaseDeDatos.cs la variable sqlString

```
private static String sqlString = "Persist Security Info=False;User ID=sa;Password=pass;Initial Catalog=EstudioExpress;Server=DESKTOP-VA9KCI4\\SQLEXPRESS";
```

Remplazando "User ID", "Password" y "Server" con lo que corresponda. 

#### Datos de prueba
usuario: admin.admin
contraseña: pass


