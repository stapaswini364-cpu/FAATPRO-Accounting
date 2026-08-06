const handleSubmit = async (e) => {

    e.preventDefault();

    setError("");
    setLoading(true);


    try {


        const response = await authService.login(formData);


        console.log(
            "LOGIN RESPONSE",
            response
        );


        localStorage.setItem(
            "token",
            response.data.token
        );


        navigate("/");


    }
    catch(error) {


        console.error(
            error
        );


        setError(
            "Invalid email or password"
        );


    }
    finally {


        setLoading(false);


    }

};