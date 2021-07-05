import {
  GET_MOVIEDETAILS,
  GET_MOVIEDETAILS_SUCCESS,
  GET_MOVIEDETAILS_FAILURE,
  GET_MOVIELIST,
  GET_MOVIELIST_SUCCESS,
  GET_MOVIELIST_FAILURE,
  GET_CASTDETAILS,
  GET_CASTDETAILS_SUCCESS,
  GET_CASTDETAILS_FAILURE
} from './actions'
import initialState from './initialState'
  
const reducer = (state = initialState, payload) => {
  //debugger;
  switch (payload.type) {
      case GET_MOVIELIST_SUCCESS:
        return {
          ...state,
          movieList: payload.data
        }
      case GET_MOVIEDETAILS_SUCCESS:
        return {
          ...state,
          movieDetails: payload.data
        }
        case GET_CASTDETAILS_SUCCESS:
          return {
            ...state,
            castDetails: payload.data
          }
      default:
        return state
    }
  }
  
export default reducer
  