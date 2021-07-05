const PREFIX = '@Movie'

export const GET_MOVIELIST = `${PREFIX}/GET_MOVIELIST`
export const GET_MOVIELIST_SUCCESS = `${PREFIX}/GET_MOVIELIST_SUCCESS`
export const GET_MOVIELIST_FAILURE = `${PREFIX}/GET_MOVIELIST_FAILURE`
export const GET_MOVIEDETAILS = `${PREFIX}/GET_MOVIEDETAILS`
export const GET_MOVIEDETAILS_SUCCESS = `${PREFIX}/GET_MOVIEDETAILS_SUCCESS`
export const GET_MOVIEDETAILS_FAILURE = `${PREFIX}/GET_MOVIEDETAILS_FAILURE`
export const GET_CASTDETAILS = `${PREFIX}/GET_CASTDETAILS`
export const GET_CASTDETAILS_SUCCESS = `${PREFIX}/GET_CASTDETAILS_SUCCESS`
export const GET_CASTDETAILS_FAILURE = `${PREFIX}/GET_CASTDETAILS_FAILURE`


export const getMovieList = () => ({
    type: GET_MOVIELIST
})

export const getMovieDetails = (id) => ({
    type: GET_MOVIEDETAILS,
    data: { id }
})

export const getCastDetails = (id) => ({
    type: GET_CASTDETAILS,
    data: { id }
})