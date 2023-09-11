namespace NetCore.Domain.Mappers.ViewModels;

public interface IEntityUpdateMapper<Source, Destination> where Source : class 
                                                          where Destination : class
{
    public Destination Map(
        Destination original,
        Source viewModel
    );
}