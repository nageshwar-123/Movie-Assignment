import { Grid, makeStyles, Typography } from '@material-ui/core';
import FiberManualRecordIcon from '@material-ui/icons/FiberManualRecord';
import React from 'react';

const useStyles = makeStyles(theme => ({
    
}));

const MovieDetailsTab = (props) => {
    const classes = useStyles();
    const {movie} = props;
    console.log("movie - ", movie)
    const getDate = () => {
        let h = Math.floor(movie.durationInMinutes / 60);
        let m = movie.durationInMinutes % 60;
        return h + "hr " + (m > 0 ? m + "min" : "" );
    }

    return (
        <>
        {
            movie &&
            <Grid container direction="row" spacing={3} justify="space-between">
                <Grid item md={6}>
                    <Grid container direction="column" spacing={3}>
                        <Grid item xs={12}>
                            <Typography variant="h1">{movie.movieName}</Typography>
                        </Grid>
                        <Grid item xs={12}>
                            <Typography variant="caption">{movie.genre}</Typography>
                            <Typography variant="caption" style={{ marginLeft: "20px" }}><FiberManualRecordIcon style={{ fontSize: 10, marginRight:"5px" }}/>{getDate()}</Typography>
                        </Grid>
                        <Grid item xs={12}>
                            <Typography variant="body">
                                {movie.description}
                            </Typography>
                        </Grid>
                    </Grid>
                </Grid>
                <Grid item md={6}>
                    <img
                        src={movie.thumbnailPath}
                        height="350px"
                        width="100%"
                        style={{ borderRadius: "3%" }}
                    />
                </Grid>
                <Grid item xs={12}>
                    <Typography variant="h3">ScreenShots</Typography>
                    <div style={{marginTop:"10px"}}>
                        {
                            [0, 1, 2, 3, 4, 5, 6].map(itm => (
                                <img 
                                    src={movie.thumbnailPath}
                                    height="100px"
                                    width="100px"
                                    style={{ marginRight: "20px", borderRadius: "10%", paddingright: "10px"}}
                                />
                            ))
                        }
                    </div>
                </Grid>
            </Grid>
        }

        </>
    )
}

export default MovieDetailsTab
