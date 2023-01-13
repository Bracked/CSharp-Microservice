using MovieService.Dtos;

namespace MovieService.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewMovie(MoviePublishedDto moviePublishedDto);
    }
}