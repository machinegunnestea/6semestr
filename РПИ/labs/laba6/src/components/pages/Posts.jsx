import React, {useEffect,  useState} from "react";
import PostService from "../../API/PostService";
import {useFetching} from "../hooks/useFetching";
import PostList from "../UI/posts/PostList";
import Pagination from "../UI/pagination/Pagination";

function Posts() {
    const [posts, setPosts]=useState([])
    const [totalPages, setTotalPages]=useState(0)
    const [limit, setLimit]=useState(10)
    const [page,setPage]=useState(1)

    const getPageCount=(totalCount, limit)=>{
        return Math.ceil(totalCount/limit)
    }

    const fetchPosts = useFetching(async (limit, page) => {
        const response=await PostService.getAll(limit, page);
        setPosts(response.data)
        const totalCount=response.headers['x-total-count']

        setTotalPages(getPageCount(totalCount, limit));
    })

    useEffect( ()=> {
        fetchPosts(limit, page)
    },[])
    const changePage= (page)=> {
        setPage(page)
        fetchPosts(limit, page)
    }

    return (
        <div className="App">
            <PostList posts={posts} title="Список постов"/>
            <Pagination totalPages={totalPages}
                        changePage={changePage}
                        page={page}/>
        </div>
    );
}

export default Posts;