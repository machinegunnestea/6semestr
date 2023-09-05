const Post = ({id,title}) => {
    return (<p key={id}>
        {id} {title}
    </p>);
}
 
export default Post;