using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Paciente
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IespinozaPruebaPacienteContext context = new DL.IespinozaPruebaPacienteContext())
                {
                    var query = context.Pacientes.FromSqlRaw($"PacienteGetAll").ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Paciente paciente = new ML.Paciente();
                            paciente.IdPaciente = obj.IdPaciente;
                            paciente.Nombre = obj.Nombre;
                            paciente.ApellidoPaterno = obj.ApellidoPaterno;
                            paciente.ApellidoMaterno = obj.ApellidoMaterno;
                            paciente.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd-mm-yyyy");
                            paciente.Sexo = char.Parse(obj.Sexo);
                            paciente.FechaIngreso = obj.FechaIngreso.Value.ToString("dd-mm-yyyy");
                            paciente.Diagnostico = obj.Diagnostico;
                            paciente.TipoSangre = new ML.TipoSangre();
                            paciente.TipoSangre.IdTipoSangre = obj.IdTipoSangre;
                            paciente.TipoSangre.Nombre = obj.Nombre;
                            result.Objects.Add(paciente);
                        }
                        result.Correct = true;
                        }
                    else
                    {
                        result.Correct = false;
                    }
                }
               
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
                
            }
        }
    }
