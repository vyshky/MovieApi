using Microsoft.Extensions.Options;
using MovieApi.Options;
using MovieApi.Services;

namespace MovieApi.Extensions
{
	public static class ServiceCollectionExtensions // используется для подключение сервисов и настройки
	{
		public static IServiceCollection AddMovieApi(this IServiceCollection services,Action<MovieApiOptions> options)
		{            
            services.AddTransient<IMovieApiServices, MovieApiServices>(); // подключение сервиса
			services.Configure<MovieApiOptions>(options);
            return services;
		}
	}
}
