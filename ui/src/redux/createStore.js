import { createStore, applyMiddleware, compose } from 'redux';
import createSagaMiddleware from 'redux-saga';
import { persistStore, persistReducer } from 'redux-persist';
import storage from 'redux-persist/lib/storage';
import reducer from './reducers/index';
import { LoginSaga } from "../pages/login";
import { Sagas as MovieSaga } from "../pages/movie/redux"

const persistConfig = {
    key: 'root',
    storage,
    whitelist: ['AuthReducer']
  }

export default () => {
    const sagaMiddleware = createSagaMiddleware()
  
    const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__
      ? window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__({})
      : compose
  
    const enhancer = composeEnhancers(applyMiddleware(sagaMiddleware))
  
    const persistedReducer = persistReducer(persistConfig, reducer)
  
    const store = createStore(persistedReducer, enhancer)
  
    const persistor = persistStore(store)
  
  sagaMiddleware.run(LoginSaga)
  sagaMiddleware.run(MovieSaga)
    
    return { store, persistor }
  }  
