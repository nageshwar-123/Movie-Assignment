import { makeStyles } from '@material-ui/core/styles';
import React, { memo } from 'react';
import { Route } from 'react-router-dom';
import Header from '../pages/header/Header';

const useStyles = makeStyles(theme => ({
  toolbar: theme.mixins.toolbar,
  content: {
    padding : '5rem'
  },
}));

const PrivateRoute = ({ component: Component, location, ...rest }) => {
  const classes = useStyles();
  const [mobileOpen, setMobileOpen] = React.useState(false);
  const handleDrawerToggle = () => {
    setMobileOpen(!mobileOpen);
  };

  return (
    <Route
      {...rest}
      render={props =>
        <>
          <Header drawerToggle={handleDrawerToggle} history={props.history}/>
          <div className={classes.content}> 
            <Component {...props} />
          </div>
        </>
      }
    />
  )
}

export default memo(PrivateRoute)
