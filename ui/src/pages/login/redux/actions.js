const PREFIX = '@Login'

export const LOGIN = `${PREFIX}/LOGIN`
export const LOGIN_SUCCESS = `${PREFIX}/LOGIN_SUCCESS`
export const LOGIN_FAILURE = `${PREFIX}/LOGIN_FAILURE`
export const LOGOUT = `${PREFIX}/LOGOUT`
export const LOGOUT_SUCCESS = `${PREFIX}/LOGOUT_SUCCESS`
export const LOGOUT_FAILURE = `${PREFIX}/LOGOUT_FAILURE`


const login = (payload, history) => ({
    type: LOGIN,
    data: { payload, history}
})

const logout = () => ({
    type: LOGOUT,
    data: {}
})

export {
    login,
    logout
}
