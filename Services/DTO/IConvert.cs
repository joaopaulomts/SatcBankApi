namespace Services.DTO;

public interface IConvert<TD, TE>
{
    public TD ToDto(TE entity);
    public TE ToEntity(TD dto);
}