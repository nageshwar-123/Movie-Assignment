export default {
    AUTH: {
        LOGIN: process.env.REACT_APP_RESTAPI_ENDPOINT +'/Users/authenticate',
    },
    MOVIE: {
        GET_MOVIES: process.env.REACT_APP_RESTAPI_ENDPOINT + "/MovieList/GetAll",
        GET_MOVIEDETAILS: process.env.REACT_APP_RESTAPI_ENDPOINT + "/MovieDetail/GetById/:id",
        GET_CASTDETAILS: process.env.REACT_APP_RESTAPI_ENDPOINT + "/Cast/GetById/:id"
    }
}