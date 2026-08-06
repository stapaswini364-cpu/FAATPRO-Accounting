import {
  Box,
  Button,
  Card,
  CardContent,
  Checkbox,
  FormControlLabel,
  IconButton,
  InputAdornment,
  TextField,
  Typography,
} from "@mui/material";

import {
  Visibility,
  VisibilityOff,
} from "@mui/icons-material";

import { useState } from "react";

import {
  useDispatch,
  useSelector,
} from "react-redux";

import {
  loginStart,
  loginSuccess,
  loginFailure,
} from "../../redux/auth/authSlice";

import authService from "../../services/authService";

import {
  useNavigate,
} from "react-router-dom";


const Login = () => {


  const dispatch = useDispatch();

  const navigate = useNavigate();


  const {
    loading,
    error
  } = useSelector(
    (state)=>state.auth
  );



  const [showPassword,setShowPassword] =
    useState(false);



  const [formData,setFormData] =
    useState({

      email:"",

      password:"",

      remember:false

    });




  const handleChange = (e)=>{


    const {
      name,
      value,
      checked
    } = e.target;



    setFormData({

      ...formData,

      [name]:
        name === "remember"
        ? checked
        : value

    });


  };






  const handleSubmit = async(e)=>{


    e.preventDefault();


    try{


      dispatch(
        loginStart()
      );



      const response =
        await authService.login(

          formData.email,

          formData.password

        );



      console.log(
        "LOGIN RESPONSE",
        response
      );



      // ==============================
      // SAVE JWT TOKEN
      // ==============================


      const accessToken =
        response?.data?.data?.accessToken;



      const refreshToken =
        response?.data?.data?.refreshToken;




      if(accessToken)
      {

        localStorage.setItem(
          "token",
          accessToken
        );

      }



      if(refreshToken)
      {

        localStorage.setItem(
          "refreshToken",
          refreshToken
        );

      }




      // ==============================
      // REDUX LOGIN
      // ==============================


      dispatch(
        loginSuccess(response)
      );



      navigate(
        "/dashboard"
      );



    }
    catch(error){


      console.error(
        "LOGIN ERROR",
        error
      );



      dispatch(

        loginFailure(

          error.response?.data?.message
          ||
          "Invalid email or password"

        )

      );


    }


  };








  return (


    <Box

      sx={{

        minHeight:"100vh",

        display:"flex",

        justifyContent:"center",

        alignItems:"center",

        backgroundColor:"#f5f6fa"

      }}

    >


      <Card

        sx={{

          width:400,

          borderRadius:3,

          boxShadow:4

        }}

      >


        <CardContent

          sx={{

            p:4

          }}

        >



          <Typography

            variant="h4"

            textAlign="center"

            fontWeight="bold"

            mb={1}

          >

            FAATPRO ERP

          </Typography>




          <Typography

            textAlign="center"

            color="text.secondary"

            mb={3}

          >

            Welcome Back

          </Typography>





          {
            error &&

            <Typography

              color="error"

              textAlign="center"

            >

              {error}

            </Typography>

          }





          <form onSubmit={handleSubmit}>



            <TextField

              fullWidth

              label="Email"

              name="email"

              placeholder="Enter email"

              value={
                formData.email
              }

              onChange={
                handleChange
              }

              margin="normal"

            />





            <TextField

              fullWidth

              label="Password"

              name="password"

              placeholder="Enter password"

              type={
                showPassword
                ?
                "text"
                :
                "password"
              }

              value={
                formData.password
              }

              onChange={
                handleChange
              }

              margin="normal"



              InputProps={{

                endAdornment:(

                  <InputAdornment

                    position="end"

                  >

                    <IconButton

                      onClick={()=>setShowPassword(
                        !showPassword
                      )}

                    >

                      {
                        showPassword
                        ?
                        <VisibilityOff/>
                        :
                        <Visibility/>
                      }


                    </IconButton>


                  </InputAdornment>

                )

              }}


            />






            <FormControlLabel

              control={

                <Checkbox

                  name="remember"

                  checked={
                    formData.remember
                  }

                  onChange={
                    handleChange
                  }

                />

              }


              label="Remember Me"

            />







            <Button

              fullWidth

              type="submit"

              variant="contained"

              size="large"

              disabled={loading}


              sx={{

                mt:2,

                mb:2

              }}

            >

              {
                loading
                ?
                "Logging in..."
                :
                "Login"
              }


            </Button>






            <Typography

              textAlign="center"

              color="primary"

              sx={{

                cursor:"pointer"

              }}

            >

              Forgot Password?

            </Typography>




          </form>



        </CardContent>


      </Card>


    </Box>


  );


};



export default Login;