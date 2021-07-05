import axios from 'axios'

import { RESTAPI_ENDPOINT } from '../constants/general'

export default () => {
  // define baseURL
  axios.defaults.baseURL = RESTAPI_ENDPOINT
}
