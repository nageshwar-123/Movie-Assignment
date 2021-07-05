import { combineReducers } from 'redux'
import AuthReducer from '../../pages/login/redux/reducer'
import MovieReducer from '../../pages/movie/redux/reducer'

export default combineReducers({
    AuthReducer,
    MovieReducer
})
