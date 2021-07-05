import { call, takeLatest, put, select } from 'redux-saga/effects'
import axios from 'axios'
import endpoints from '../../../constants/endpoints'
import {
  GET_MOVIELIST,
  GET_MOVIELIST_SUCCESS,
    GET_MOVIELIST_FAILURE,
    GET_MOVIEDETAILS,
    GET_MOVIEDETAILS_SUCCESS,
    GET_CASTDETAILS,
  GET_CASTDETAILS_SUCCESS,
  GET_CASTDETAILS_FAILURE
} from './actions'
import { sessionTokenSelector } from '../../login/redux/selectors';

function getMovieListCall(sessionToken) {
    const config = {
     headers : {
       'Content-Type': 'application/json',
       'Authorization': 'Bearer ' + sessionToken
     }
   }
  return axios.get(endpoints.MOVIE.GET_MOVIES, config)
 }

function* getMovieList() {
  try {
    const sessionToken = yield select(sessionTokenSelector);
    const response = yield call(getMovieListCall, sessionToken);
    const data = response.data;
    if (data) {
      yield put({ type: GET_MOVIELIST_SUCCESS, data })
    } else {
      
    }
  } catch (error) {
    
  }
}

function getCastDetailsCall(payload, sessionToken) {
  const config = {
    headers: {
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + sessionToken
    }
  }
  return axios.get(endpoints.MOVIE.GET_CASTDETAILS.replace(":id", payload.data.id), config)
}


function getMovieDetailsCall(payload, sessionToken) {
  const config = {
    headers: {
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + sessionToken
    }
  }
  return axios.get(endpoints.MOVIE.GET_MOVIEDETAILS.replace(":id", payload.data.id), config)
}

function* getMovieDetails(payload) {
  try {
    const sessionToken = yield select(sessionTokenSelector);
    const response = yield call(getMovieDetailsCall, payload, sessionToken);
    const data = response.data;
    console.log("MovieDetail:-" + data)
    if (data && data.length > 0) {
      yield put({ type: GET_MOVIEDETAILS_SUCCESS, data: data[0] })
    } else {
      
    }
    //debugger;
    //getCastDetails(payload);
    
  } catch (error) {
    
  }
}

function* getCastDetails(payload) {
  try {
    const sessionToken = yield select(sessionTokenSelector);
    const response = yield call(getCastDetailsCall, payload, sessionToken);
    const data = response.data;
    console.log("CastDetail:-" + data)
    if (data && data.length > 0) {
      yield put({ type: GET_CASTDETAILS_SUCCESS, data })
    } else {
      
    }
  } catch (error) {
    
  }
}

// watcher saga: watches for actions dispatched to the store, starts worker saga
export default function* watcherSaga() {
  yield takeLatest(GET_MOVIELIST, getMovieList)
  yield takeLatest(GET_MOVIEDETAILS, getMovieDetails)
  yield takeLatest(GET_CASTDETAILS, getCastDetails)
}