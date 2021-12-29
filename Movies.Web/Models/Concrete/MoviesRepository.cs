using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Movies.Web.Models.Abstract;
namespace Movies.Web.Models.Concrete
{
    public class MoviesRepository : IMovies
    {
        private readonly IConfiguration iConfiguration;
        private SqlConnection sqlConnection;
        private List<MoviesVO> movies;
        private DataSet _ds;
        private MoviesVO movie;
        public MoviesRepository(IConfiguration _IConfiguration)
        {
            iConfiguration = _IConfiguration;
        }

        public List<MoviesVO> Get(int intSrNo)
        {
            sqlConnection = new SqlConnection(iConfiguration.GetConnectionString("conMovies"));
            SqlCommand sqlCommand = new SqlCommand("usp_get_movies_by_id", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@srno", intSrNo));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            _ds = new DataSet();
            sqlDataAdapter.Fill(_ds);
            if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
            {
                movies = new List<MoviesVO>();
                foreach (DataRow item in _ds.Tables[0].Rows)
                {
                    movie = new MoviesVO();
                    movie.srno = Convert.ToInt32(item["srno"]);
                    movie.years = Convert.ToInt32(item["years"]);
                    movie.mname = Convert.ToString(item["mname"]);
                    movie.dname = Convert.ToString(item["dname"]);
                    movie.actress = Convert.ToString(item["actress"]);
                    movie.actor = Convert.ToString(item["actor"]);
                    movies.Add(movie);
                }
            }
            return movies;
        }
        public List<MoviesVO> GetByActorName(string strActorName)
        {
            sqlConnection = new SqlConnection(iConfiguration.GetConnectionString("conMovies"));
            SqlCommand sqlCommand = new SqlCommand("usp_Get_movies", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@actor", strActorName));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            _ds = new DataSet();
            sqlDataAdapter.Fill(_ds);
            if (_ds != null && _ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
            {
                movies = new List<MoviesVO>();
                foreach (DataRow item in _ds.Tables[0].Rows)
                {
                    movie = new MoviesVO();
                    movie.srno = Convert.ToInt32(item["srno"]);
                    movie.years = Convert.ToInt32(item["years"]);
                    movie.mname = Convert.ToString(item["mname"]);
                    movie.dname = Convert.ToString(item["dname"]);
                    movie.actress = Convert.ToString(item["actress"]);
                    movie.actor = Convert.ToString(item["actor"]);
                    movies.Add(movie);
                }
            }
            return movies;
        }

        public int Set(MoviesVO moviesVO)
        {
            sqlConnection = new SqlConnection(iConfiguration.GetConnectionString("conMovies"));
            SqlCommand sqlCommand = new SqlCommand("usp_set_movies", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@srno", moviesVO.srno));
            sqlCommand.Parameters.Add(new SqlParameter("@mname", moviesVO.mname));
            sqlCommand.Parameters.Add(new SqlParameter("@years", moviesVO.years));
            sqlCommand.Parameters.Add(new SqlParameter("@actor", moviesVO.actor));
            sqlCommand.Parameters.Add(new SqlParameter("@actress", moviesVO.actress));
            sqlCommand.Parameters.Add(new SqlParameter("@dname", moviesVO.dname));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return 1;
        }
    }
}
