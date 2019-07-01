using System;
using System.Collections.Generic;
using System.Data;


public class GestorDeCursos
{
    private static GestorDeCursos instancia;
    private BaseDeDatos baseDeDatos;

    private String sqlCrearCursoConEpisodios =
    "begin tran;"
    + "DECLARE @AuxTable TABLE (id INT);"
    + "DECLARE @id int;"
    + "INSERT INTO CURSO (nombre ,duracion ,descripcion ,precio) OUTPUT INSERTED.idCurso INTO @AuxTable(id) VALUES ('%nombre%' ,%duracion% ,'%descripcion%' ,%precio%);"
    + "SET @id = (select id from @AuxTable);"
    + "%episodios%"
    + "commit tran;";

    private String sqlCrearEpisodio = "INSERT INTO EPISODIO (numeroEpisodio, direccionVideo, descripcion, idCurso) VALUES (%numeroEpisodio%, '%direccionVideo%', '%descripcion%', @id);";


    private GestorDeCursos()
    {
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
    }

    public static GestorDeCursos ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeCursos();
        }

        return instancia;
    }

    public int CrearCurso(CursoEntidad curso, int usuarioEnSesion)
    {

        if (baseDeDatos.ConsultarBase(String.Format("SELECT * FROM CURSO WHERE nombre = '{0}'", curso.nombre)).Rows.Count > 0)
        {
            throw new EntidadDuplicadaExcepcion("nombre");
        }

        var episodios = "";

        foreach (Episodio episodio in curso.Episodios)
        {
            episodios = sqlCrearEpisodio.Replace("%numeroEpisodio%", episodio.numeroEpisodio + "").Replace("%direccionVideo%", episodio.direccionVideo).Replace("%descripcion%", episodio.descripcion);
        }

        var registros = baseDeDatos.ModificarBase(sqlCrearCursoConEpisodios.Replace("%episodios%", episodios)
            .Replace("%nombre%", curso.nombre)
            .Replace("%duracion%", curso.duracion + "")
            .Replace("%descripcion%", curso.descripcion)
            .Replace("%precio%", curso.precio + ""));

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se crea el curso" + curso.nombre, criticidad = 3, funcionalidad = "ADMINISTRACION DE CURSOS", usuario = new Usuario() { identificador = usuarioEnSesion } };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);


        return registros;
    }


    public CursoEntidad ObtenerCurso(int identificador)
    {
        var dataTable = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM CURSO where idCurso = {0}", identificador));
        CursoEntidad curso = new CursoEntidad();
        foreach (DataRow row in dataTable.Rows)
        {
            curso = CursoRow(row);

            curso.Episodios = ObtenerEpisodiosDeUnCurso(curso.identificador);
        }
        return curso;
    }

    public List<CursoEntidad> ObtenerCursos()
    {
        var dataTable = baseDeDatos.ConsultarBase("SELECT * FROM CURSO");
        List<CursoEntidad> cursos = new List<CursoEntidad>();
        foreach (DataRow row in dataTable.Rows)
        {
            CursoEntidad curso = CursoRow(row);

            curso.Episodios = ObtenerEpisodiosDeUnCurso(curso.identificador);
            cursos.Add(curso);

        }
        return cursos;
    }

    public int AsignarCursoAUsuario(CursoEntidad curso, Usuario usuario)
    {
        var registros = baseDeDatos.ModificarBase(String.Format("INSERT INTO USUARIOCURSO (curso_idCurso, usuario_idUsuario) VALUES ({0}, {1})", curso.identificador, usuario.identificador));


        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se asigno el " + curso.nombre + " al usuario" + usuario.identificador, criticidad = 3, funcionalidad = "ADMINISTRACION DE CURSOS", usuario = usuario };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);

        return registros;
    }

    public List<CursoEntidad> ObtenerCursosDeUnUsuario(int usuario)
    {
        var dataTable = baseDeDatos.ConsultarBase(String.Format("SELECT * from curso inner join usuariocurso on usuariocurso.curso_idCurso = curso.idCurso where usuariocurso.Usuario_idUsuario = {0}", usuario));
        List<CursoEntidad> cursos = new List<CursoEntidad>();
        foreach (DataRow row in dataTable.Rows)
        {
            CursoEntidad curso = CursoRow(row);

            curso.Episodios = ObtenerEpisodiosDeUnCurso(curso.identificador);
            cursos.Add(curso);

        }
        return cursos;
    }

    public bool EsUnCursoAsignadoAlUsuario(int curso, int usuario)
    {

        var dataTable = baseDeDatos.ConsultarBase(String.Format("SELECT * from curso inner join usuariocurso on usuariocurso.curso_idCurso = curso.idCurso where usuariocurso.Usuario_idUsuario = {0} and curso.idCurso = {1}", usuario, curso));

        return dataTable.Rows.Count > 0;

    }

    public CursoEntidad CursoRow(DataRow row)
    {
        CursoEntidad curso = new CursoEntidad();

        curso.nombre = Convert.ToString(row["nombre"]);
        curso.identificador = Convert.ToInt32(row["idCurso"]);
        curso.precio = Convert.ToDecimal(row["precio"]);
        curso.duracion = Convert.ToInt32(row["duracion"]);
        return curso;
    }

    public List<Episodio> ObtenerEpisodiosDeUnCurso(int curso)
    {
        var dataTable = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM EPISODIO where episodio.idCurso = {0} order by numeroEpisodio ASC", curso));

        List<Episodio> episodios = new List<Episodio>();
        foreach (DataRow row in dataTable.Rows)
        {
            Episodio episodio = new Episodio();
            episodio.nombre = Convert.ToString(row["nombre"]);
            episodio.descripcion = Convert.ToString(row["descripcion"]);
            episodio.direccionVideo = Convert.ToString(row["direccionVideo"]);
            episodio.numeroEpisodio = Convert.ToInt32(row["numeroEpisodio"]);
            episodios.Add(episodio);
        }

        return episodios;

    }

}

