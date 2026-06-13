PEAK and Top mean similar things.<br>
HTTP and WebSockets both use a network Socket. <br>
Put the two together, and you get "TopSocket".

I am still bad at making names.

The current port for HTTP and WebSocket is `9347`. That might change in future.

The HTTP path is `/status.json`. Send a GET to there.
The WebSocket path is `/sock`.