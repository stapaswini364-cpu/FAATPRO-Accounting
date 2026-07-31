import api from "./axios";


export const login = (credentials) => {

    return api.post(
        "/Auth/login",
        credentials
    );

};



export const logout = () => {

    return api.post(
        "/Auth/logout"
    );

};



export const refreshToken = () => {

    return api.post(
        "/Auth/refresh-token"
    );

};



export const getCurrentUser = () => {

    return api.get(
        "/Auth/me"
    );

};