import paths from './constants/paths';
import Login from './pages/login';
import MovieList from './pages/movie/MovieList';
import MovieDetails from './pages/movie/MovieDetails';

export default {
    DEFAULT:{
        component: Login,
        route: paths.DEFAULT
    },
    MOVIES: {
        component: MovieList,
        route: paths.MOVIES
    },
    MOVIE: {
        component: MovieDetails,
        route: paths.MOVIE
    }
}
