import { Box, Chip, Grid, makeStyles, Tab, Tabs, Typography } from '@material-ui/core';
import { withStyles } from '@material-ui/core/styles';
import DoneIcon from '@material-ui/icons/Done';
import React, { useEffect} from 'react';
import { connect } from 'react-redux';
import CastTab from './CastTab';
import MovieDetailsTab from './MovieDetailsTab';
import { getMovieDetails, getCastDetails } from './redux/actions';

const useStyles = makeStyles(theme => ({
    tabs: { 
        borderRight: `1px solid ${theme.palette.divider}`
    },
    tabPanel: {
        padding: '10px',
        margin: '20px',
        width: '100%',
        minWidth: 250,
    }
}));

function a11yProps(index) {
    return {
        id: `simple-tab-${index}`,
        "aria-controls": `simple-tabpanel-${index}`,
    };
}

function TabPanel(props) {
    const { children, value, index, ...other } = props;

    return (
        <Typography
            component="div"
            role="tabpanel"
            hidden={value !== index}
            id={`simple-tabpanel-${index}`}
            aria-labelledby={`simple-tab-${index}`}
            {...other}
        >
            {value === index && <Box p={0}>{children}</Box>}
        </Typography>
    );
}

const MovieDetails = (props) => {
    const classes = useStyles();
    const [tabValue, setTabValue] = React.useState(0);
    const [markSeen, setMarkSeen] = React.useState(false);

    useEffect(() => {
		props.getMovieDetails(props.match.params.id);
        props.getCastDetails(props.match.params.id);
	}, [])

    const handleChange = (event, newValue) => {
        setTabValue(newValue);
    };

    const handleMark = () => {
        setMarkSeen(!markSeen);
    };

    return (
        <>
        
            <Grid container spacing={4}>
                <Grid item xs={12}>
                    <Grid container justify="space-between"alignItems="center">
                        <Grid item>
                            <Typography variant="h2">Movie Details</Typography>
                        </Grid>
                        <Grid item>
                            <Chip
                                icon={markSeen ? <DoneIcon /> : <></>}
                                label={markSeen ? "Mark as unseen" : "Mark as seen"}
                                clickable
                                color="primary"
                                style={markSeen ? { backgroundColor: '#64dd17' } : {}}
                                onClick={handleMark}
                                variant={markSeen ? "default" : "outlined"}
                            />
                            <Chip
                                label="Add to watchlist"
                                clickable
                                color="primary"
                                variant="outlined"
                                style={{marginLeft:"20px"}}
                            />
                        </Grid>
                    </Grid>
                </Grid>
                <Grid item xs={12}>
                    <Grid container direction="row" spacing={3}>
                        
                        <Grid item md={4}>
                        {props.movieDetails && props.movieDetails.thumbnailPath &&
                            <img
                                src={props.movieDetails.thumbnailPath}
                                height="600px"
                                width="100%"
                                style={{ borderRadius: "3%" }}
                            />
                        }
                        </Grid>
                        <Grid item md={8}>
                            <Tabs
                                value={tabValue}
                                variant="scrollable"
                                onChange={handleChange}
                                className={classes.tabs}
                                indicatorColor="primary"
                            >
                                <Tab label="Details" {...a11yProps(1)} />
                                <Tab label="Cast" {...a11yProps(2)} />
                            </Tabs>
                            <TabPanel value={tabValue} index={0} className={classes.tabPanel}>
                                
                                <MovieDetailsTab movie={props.movieDetails}/>
                            </TabPanel>
                            <TabPanel value={tabValue} index={1} className={classes.tabPanel}>
                                <CastTab casts={props.castDetails}/>
                            </TabPanel>

                        </Grid>
                    </Grid>
                </Grid>
            </Grid>
            
            
                        
        </>
    )
}

const mapStateToProps = state => ({
    movieDetails: state.MovieReducer.movieDetails,
    castDetails: state.MovieReducer.castDetails
})

const mapDispatchtoProps = dispatch => {
    return {
        getMovieDetails: (id) => dispatch(getMovieDetails(id)),
        getCastDetails: (id) => dispatch(getCastDetails(id))
    }
}

export default connect(
    mapStateToProps,
    mapDispatchtoProps
)(MovieDetails)