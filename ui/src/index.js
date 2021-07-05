import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './containers/App';
import AppThemeProvider from './containers/AppThemeProvider'
import * as serviceWorker from './serviceWorker';
import { Provider } from 'react-redux'
import { PersistGate } from 'redux-persist/integration/react'
import configureAxios from './services/configureAxios'
import createStore from './redux/createStore'

const { store, persistor } = createStore()

configureAxios()

ReactDOM.render(
  <Provider store={store}>
    <PersistGate loading={null} persistor={persistor}>
      <AppThemeProvider>
          <App />
      </AppThemeProvider>
    </PersistGate> 
  </Provider>,
  document.getElementById('root')
)
serviceWorker.register()
