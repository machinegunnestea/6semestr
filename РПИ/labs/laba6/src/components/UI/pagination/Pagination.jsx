import React from 'react';
import cl from "./Pagination.module.css";

const Pagination = ({changePage, totalPages, page }) => {
    const getPagesArray=(totalPages)=>{
        let result=[]
        for(let i=0;i<totalPages;i++){
            result.push(i+1);
        }

        return result
    }
    let pagesArray=getPagesArray(totalPages)

    return (
        <div className={cl.page__wrapper}>
      <span
          className={cl.page__normal}
          onClick={() => {
              if (page > 1) {
                  changePage(page - 1);
              }
          }}
      >
        Prev
      </span>
        {pagesArray.map((p) => (
            <span
                onClick={() => changePage(p)}
                key={p}
                className={
                    page === p
                        ? [cl.page__normal, cl.page__current].join(" ")
                        : cl.page__normal
                }
            >
      {p}
        </span>
            ))}

        <span
            className={cl.page__normal}
            onClick={() => {
                if (page < totalPages) {
                    changePage(page + 1);
                }
            }}
        >
        Next
      </span>
        </div>
    );
};

export default Pagination;