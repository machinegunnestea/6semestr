import React, { useState, useEffect } from "react";
import Post from "./Post";

function Posts({ count, limit }) {
  const [posts, setPosts] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);

  useEffect(() => {
    fetch(
      `https://jsonplaceholder.typicode.com/posts?_page=${currentPage}&_limit=${limit}`
    )
      .then((response) => response.json())
      .then((data) => setPosts(data));
  }, [currentPage]);

  const totalPages = Math.ceil(count / limit);

  const handlePrevious = () => {
    setCurrentPage(currentPage - 1);
  };

  const handleNext = () => {
    setCurrentPage(currentPage + 1);
  };
  
  const buttons = [];
  for (let i = 1; i <= totalPages; i++) {
    buttons.push(
      <button key={i} onClick={() => setCurrentPage(i)}>
        <span>{i}</span>
      </button>
    );
  }

  return (
    <div>
        <p>Отображение постов:</p>
      {posts.length ? (
        <div>{
          posts.map((post) => (
            <Post id={post.id} title={post.title}/>
          ))
          }</div>
      ) : (
        <div>
          <p>Достигнут лимит по постам</p>
        </div>
      )}
      <div>
        <button onClick={handlePrevious} disabled={currentPage === 1}>
          Предыдущая
        </button>

        {buttons}
        <button onClick={handleNext} disabled={currentPage === totalPages}>
        Следующая
        </button>
      </div>
    </div>
  );
}
export default Posts;
