import { useState } from "react";
import { useNavigate } from "react-router-dom";

import authService from "../../services/authService";



const Login = () => {


  const navigate = useNavigate();


  const [formData, setFormData] = useState({

    email: "",
    password: ""

  });


  const [loading, setLoading] = useState(false);


  const [error, setError] = useState("");



  const handleChange = (e) => {


    setFormData({

      ...formData,

      [e.target.name]: e.target.value

    });


  };



  const handleSubmit = async (e) => {


    e.preventDefault();


    setError("");

    setLoading(true);



    try {


      await authService.login(formData);


      navigate("/");


    }

    catch(error) {


      setError(
        "Invalid email or password"
      );


    }

    finally {


      setLoading(false);


    }


  };



  return (

    <div className="min-h-screen flex items-center justify-center bg-gray-100">


      <div className="bg-white p-8 rounded-xl shadow-md w-full max-w-md">


        <h1 className="text-3xl font-bold text-center mb-6">

          FAATPRO Login

        </h1>



        {
          error && (

            <div className="bg-red-100 text-red-600 p-3 rounded mb-4">

              {error}

            </div>

          )
        }




        <form onSubmit={handleSubmit}>


          {/* Email */}

          <div className="mb-4">


            <label className="block mb-2">

              Email

            </label>



            <input

              type="email"

              name="email"

              value={formData.email}

              onChange={handleChange}

              placeholder="Enter email"

              className="w-full border rounded-lg px-4 py-2"

              required

            />


          </div>





          {/* Password */}

          <div className="mb-4">


            <label className="block mb-2">

              Password

            </label>



            <input

              type="password"

              name="password"

              value={formData.password}

              onChange={handleChange}

              placeholder="Enter password"

              className="w-full border rounded-lg px-4 py-2"

              required

            />


          </div>





          {/* Remember Me */}

          <div className="flex items-center mb-5">


            <input

              type="checkbox"

              className="mr-2"

            />


            Remember Me


          </div>





          {/* Login Button */}

          <button

            type="submit"

            disabled={loading}

            className="w-full bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700 disabled:bg-gray-400"

          >

            {
              loading
              ?
              "Logging in..."
              :
              "Login"
            }


          </button>



        </form>





        {/* Forgot Password */}

        <div className="text-center mt-4">


          <button

            className="text-blue-600"

          >

            Forgot Password?

          </button>


        </div>



      </div>


    </div>

  );

};


export default Login;