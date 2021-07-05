import { Card, CardActionArea, CardMedia, Grid, Typography } from '@material-ui/core';
import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import TextInput from '../../components/TextInput';
import { getMovieList } from './redux/actions';

const MovieItem = (props) => {
    const { movie } = props;
    const openMovie = () => {
        props.history.push("/movie/" + movie.movieId);
    };

    return (
        <Card style={{width:'170px'}}>
            <CardActionArea>
                <CardMedia
                    component="img"
                    alt="Contemplative Reptile"
                    onClick={openMovie}
                    //image="https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcTN9fSAAmfgi3KXjCr2NGYl2tm_hzpwejH9-WHfuCOA7ZpdG2Ys"
                    image={movie.thumbnails && movie.thumbnails.length > 0 && movie.thumbnails[0].thumbnailPath}
                    title={movie.name}
                />
            </CardActionArea>
        </Card>
    )
}

const MovieList = (props) => {
    useEffect(() => {
		props.getMovieList();
	}, [])

    useEffect(() => {
		console.log("movielist-", props.movieList)
	}, [props.movieList])

    return (
        <div>
            <Grid container justify="space-between"
                alignItems="center">
                <Grid item>
                    <Typography variant="h2">Movies</Typography>
                </Grid>
                <Grid item>
                    <TextInput label="Search.."/>
                </Grid>
            </Grid>
            <Grid container direction="row" spacing={3} style={{marginTop:"20px"}}>
            {
                props.movieList && props.movieList.length > 0 && props.movieList.map(movie => (
                    <Grid item>
                        <MovieItem history={ props.history } movie={movie} />
                    </Grid>
                )) 
            }

            </Grid>
        </div>
    )
}

const mapStateToProps = state => ({
    movieList: state.MovieReducer.movieList,
})

const mapDispatchtoProps = dispatch => {
    return {
        getMovieList: () => dispatch(getMovieList())
    }
}

export default connect(
    mapStateToProps,
    mapDispatchtoProps
)(MovieList)
