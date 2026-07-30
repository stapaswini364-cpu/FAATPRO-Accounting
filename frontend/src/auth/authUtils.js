export const isAuthenticated = () => {


    const token = localStorage.getItem("token");


    return !!token;


};



export const logoutUser = () => {


    localStorage.removeItem("token");


    window.location.href="/login";


};