import { call, takeLatest, put } from 'redux-saga/effects'
import axios from 'axios'
import endpoints from '../../../constants/endpoints'
import {
    LOGIN,
    LOGIN_SUCCESS,
    LOGIN_FAILURE
} from './actions'


function loginCall(payload) {
    const config = {
     headers : {
       'Content-Type': 'application/json'
     },
     withCredentials: true
   }
   return axios.post(endpoints.AUTH.LOGIN , payload ,config)
 }

function* login(payload) {
  try {
    const response = yield call(loginCall, payload.data.payload);
    const data = response.data;
    if (data) {
      yield put({ type: LOGIN_SUCCESS, data })
      payload.data.history.push('/movies');
    } else {
      yield put({
        type: LOGIN_FAILURE,
        data: {
          message: 'Login failed',
        },
      })
    }
  } catch (error) {
    yield put({
      type: LOGIN_FAILURE,
      data: {
        message: 'Login failed',
      },
    })
  }
}

// watcher saga: watches for actions dispatched to the store, starts worker saga
export default function* watcherSaga() {
  yield takeLatest(LOGIN, login)
}