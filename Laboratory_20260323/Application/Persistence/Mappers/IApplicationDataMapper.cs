namespace Laboratory_20260323.Application.Persistence.Mappers;

public interface IApplicationDataMapper
{
    ApplicationDataSnapshot ToSnapshot(ApplicationDataState state);
    ApplicationDataState ToDomain(ApplicationDataSnapshot snapshot);
}
