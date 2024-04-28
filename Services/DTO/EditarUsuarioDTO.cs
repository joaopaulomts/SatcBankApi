using Entities;

namespace Services.DTO;

public class EditarUsuarioDTO
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Senha { get; set; }

    public static EditarUsuarioDTO ToDto(Usuario entity)
    {
        return new EditarUsuarioDTO
        {
            Nome = entity.Nome,
            Cpf = entity.Cpf,
            Senha = entity.Senha
        };
    }

    public static Usuario ToEntity(EditarUsuarioDTO dto)
    {
        return new Usuario
        {
            Nome = dto.Nome,
            Cpf = dto.Cpf,
            Senha = dto.Senha
        };
    }
}