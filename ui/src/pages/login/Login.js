import { Button, Grid, Paper } from '@material-ui/core';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography';
import React, { useState } from 'react';
import { connect } from 'react-redux';
import TextInput from '../../components/TextInput';
import { login } from './redux/actions';

const useStyles = makeStyles((theme) => ({
  layout: {
    width: 'auto',
    marginLeft: theme.spacing(2),
    marginRight: theme.spacing(2),
    marginBottom: 10,
    [theme.breakpoints.up(1000 + theme.spacing(2) * 2)]: {
      marginLeft: 'auto',
      marginRight: 'auto',
    },
    display: "flex",
    // alignItems: "center",
    flexDirection: "column",
    justifyContent: "center",
    minHeight: "100vh",
    background: "#fff",
    fontFamily: "'proxima-nova', 'Source Sans Pro', 'sans-serif'",
    fontSize: "1rem",
    letterSpacing: "0.1px",
    color: "#32465a",
    textRendering: "optimizeLegibility",
    textShadow: "1px 1px 1px rgba(0, 0, 0, 0.004)",
    //-webkit-font-smoothing: antialiased;
    overflow: "hidden",
    background: "#004191"
  },
}));

const Login = (props) => {
  const classes = useStyles();
const [email, setEmail] = useState("");
const [password, setPassword] = useState("");

  const handleSubmit = () => {
    const payload = {
      username : email,
      password : password
  }
  
    props.login(payload, props.history)
  }

  return (
    <React.Fragment>
      <div className={classes.layout}>
      <Grid container direction="column" justify="center" alignItems="center">
          <Grid item xs={12} md={4} >
            <Grid container alignItems="center" justify="center">
              <Grid item>
              <img
                    src="data:image/png;base64,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"
                    height="40px"
                    style={{ borderRadius: "3%" }}
                />
            </Grid>
            </Grid>
          </Grid>
        </Grid>
      <Grid container justify="center" alignItems="center" style={{marginTop: "50px"}}>
          <Grid item xs={12} md={4}>
              <Paper>
                <Grid container direction="column"justify="center" alignItems="center" spacing={3}>
                  <Grid item>
                    <Typography variant="h5"> Sign In</Typography>
                  </Grid>
                  <Grid item>
                    <Grid container direction="column" spacing={2}>
                      <Grid item><TextInput label="Username" fullwidth value={email} onChange={e => setEmail(e.target.value)}/></Grid>
                      <Grid item><TextInput label="Password" fullwidth value={password} onChange={e => setPassword(e.target.value)} type="password"/></Grid>
                    </Grid>
                  </Grid>
                  <Grid item>
                    <Button color="primary" variant="contained" onClick={handleSubmit} style={{borderRadius:50}}>Sign in</Button>
                  </Grid>
                </Grid>
              </Paper>
            </Grid>
          </Grid>
      </div>
    </React.Fragment>
  );
}


const mapStateToProps = state => ({
  //movieList: state.MovieReducer.movieList,
})

const mapDispatchtoProps = dispatch => {
  return {
      login: (payload, history) => dispatch(login(payload, history))
  }
}

export default connect(
  mapStateToProps,
  mapDispatchtoProps
)(withStyles(useStyles)(Login))
