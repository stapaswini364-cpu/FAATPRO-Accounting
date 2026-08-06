import api from "../api/axios";


const login = async (formData) => {


    const response = await api.post(
        "/Auth/login",
        {
            email: formData.email,
            password: formData.password
        }
    );


    const data = response.data;


    console.log(
        "LOGIN RESPONSE",
        data
    );


    // JWT Token Save

    if(data.token)
    {

        localStorage.setItem(
            "token",
            data.token
        );

    }


    // User Save

    if(data.user)
    {

        localStorage.setItem(
            "user",
            JSON.stringify(data.user)
        );

    }


    return data;

};





const logout = async()=>{


    try{

        await api.post(
            "/Auth/logout"
        );

    }
    catch(error)
    {

        console.error(error);

    }


    localStorage.removeItem(
        "token"
    );


    localStorage.removeItem(
        "user"
    );


};





const authService = {

    login,

    logout

};



export default authService;