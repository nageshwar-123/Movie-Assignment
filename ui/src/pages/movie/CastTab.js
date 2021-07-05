import { Grid, makeStyles } from '@material-ui/core';
import React from 'react';

const CastTab = (props) => {
    //const classes = useStyles();
const {casts} = props;
console.log("cast - ", casts);
    return (
        <>
            <Grid container>
                { 
                    casts && casts.length > 0 && casts.map(cast => (
                        <Grid item>
                            <Grid container direction="column" alignItems="center">
                                <Grid item >
                                    <img
                                        src={cast.thumbnails && cast.thumbnails.length > 0 && cast.thumbnails[0].thumbnailPath}
                                        height="100px"
                                        width="100px"
                                        style={{ borderRadius: "10%", padding: "10px" }}
                                    />
                                </Grid>
                                <Grid item >{cast.castName}</Grid>
                                <Grid item >{cast.character}</Grid>
                            </Grid>
                        </Grid>
                    ))
                
                }
            </Grid>
        </>
    )
}

export default CastTab
