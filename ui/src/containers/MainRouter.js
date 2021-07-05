/* eslint-disable import/no-named-as-default-member */
/* eslint-disable import/no-named-as-default */

import React, { memo } from 'react'
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom'
import routes from '../routes'
import PrivateRoute from './PrivateRoute'

const MainRouter = (props) => {
  return (
    <Router>
      <Switch>
        <Route path={routes.DEFAULT.route} component={routes.DEFAULT.component} exact />
        <PrivateRoute path={routes.MOVIES.route} component={routes.MOVIES.component} exact />
        <PrivateRoute path={routes.MOVIE.route} component={routes.MOVIE.component} exact />
      </Switch>
    </Router>
  )
}

export default memo(MainRouter)
