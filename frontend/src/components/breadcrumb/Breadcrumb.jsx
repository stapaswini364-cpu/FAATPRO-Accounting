import { Link, useLocation } from "react-router-dom";


const Breadcrumb = () => {

  const location = useLocation();

  const pathNames = location.pathname
    .split("/")
    .filter((item) => item);


  return (

    <div className="mb-4 text-sm text-gray-600">

      <Link 
        to="/"
        className="hover:text-blue-600"
      >
        Home
      </Link>


      {
        pathNames.map((name,index)=>(

          <span key={index}>

            {" / "}

            <span className="capitalize">
              {name}
            </span>

          </span>

        ))
      }


    </div>

  );

};


export default Breadcrumb;