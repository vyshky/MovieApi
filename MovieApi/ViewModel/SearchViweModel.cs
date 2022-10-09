namespace MovieApi.ViewModel
{
	public class SearchViweModel
	{
		//prop + 2 раза tab	- для создания проперти
		public IEnumerable<Movie> Movies { get; set; }
		public string Title { get; set; }
        public int CurrentPage { get; set; }
        public int TotalResults { get; set; }
		public int TotalPages { get; set; }		
	}
}
