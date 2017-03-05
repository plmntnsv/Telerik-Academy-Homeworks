/*jshint esversion: 6 */

function solve() {

	function validator(param) {
		if (param < 3 || param > 25) {
			throw "String out of range exception";
		}
	}

	let getId = (function () {
		let id = 0;

		function next() {
			id += 1;
			return id;
		}
		return {
			next: next
		};
	})();

	class Player {
		constructor(name) {
			validator(name);
			this.name = name;
			this.playerPlayLists = [];
		}

		addPlaylist(playlistToAdd) {
			if (playlistToAdd instanceof PlayList) {
				this.playerPlayLists.push(playlistToAdd);
			} else {
				throw "You are trying to add invalid playlist.";
			}

			return this;
		}

		getPlaylistById(id) {
			let playlist = this.playerPlayLists.find(p => p.id === id) || null;
			return playlist;
		}

		removePlaylist(arg) {
			let playlistIndex;
			if (typeof (arg) === 'number') {
				playlistIndex = this.playerPlayLists.findIndex(p => p.id === arg);
			} else {
				playlistIndex = this.playerPlayLists.findIndex(p => p.name === arg.name);
			}

			if (playlistIndex === -1) {
				throw "No such playlist found.";
			}

			this.playerPlayLists.splice(playlistIndex, 1);

			return this;
		}

		listPlaylists(page, size) {
			let COUNT_OF_PLAYLISTS_IN_PLAYER = this.playerPlayLists.length;
			if (page * size >= COUNT_OF_PLAYLISTS_IN_PLAYER || page < 0 || size <= 0) {
				throw "Invalid parameters provided";
			}

			let sortedPlaylists = this.playerPlayLists.sort((a, b) => a.name - b.name || a.id - b.id);
			let result = sortedPlaylists.slice(page * size, (page + 1) * size);

			return result;
		}

		contains(playable, playlist) {
			let result = playlist.some(p => p.id === playable.id);

			return result;
		}

		search(pattern) {
			let result = [];
			this.playerPlayLists
				.forEach(plr => plr.playlistPlayables
					//.forEach(plb => plb.title.includes(pattern) ? result.push( { name: plr.name, id: plr.id } ) : result.push(plr.name)));
					.forEach(function (plb) {
						if (plb.title.includes(pattern)) {
							result.push({
								name: plr.name,
								id: plr.id
							});
						}
					}));
			return result;
		}
	}

	class PlayList {
		constructor(name) {
			validator(name);
			this.name = name;
			this.id = getId.next();
			this.playlistPlayables = [];
		}

		addPlayable(playable) {
			this.playlistPlayables.push(playable);
			return this;
		}

		getPlayableById(id) {
			let playable = this.playlistPlayables.find(p => p.id === id) || null;
			return playable;
		}

		removePlayable(arg) {
			let playableIndex;
			if (typeof (arg) === 'number') {
				playableIndex = this.playlistPlayables.findIndex(p => p.id === arg);
			} else {
				playableIndex = this.playlistPlayables.findIndex(p => p.title === arg.title);
			}

			if (playableIndex === -1) {
				throw "No such playable found.";
			}

			this.playlistPlayables.splice(playableIndex, 1);

			return this;
		}

		listPlayables(page, size) {
			let COUNT_OF_PLAYABLES_IN_PLAYER = this.playlistPlayables.length;
			if (page * size >= COUNT_OF_PLAYABLES_IN_PLAYER || page < 0 || size <= 0) {
				throw "Invalid parameters provided";
			}

			let sortedPlayables = this.playlistPlayables.sort((a, b) => a.name - b.name || a.id - b.id);
			let result = sortedPlayables.slice(page * size, (page + 1) * size);
			return result;
		}

	}

	class Playable {
		constructor(title, author) {
			validator(title);
			validator(author);
			this.title = title;
			this.author = author;
			this.id = getId.next();
		}

		play() {
			let result = `[${this.id}]. [${this.title}] - [${this.author}]`;
			return result;
		}
	}

	class Audio extends Playable {
		constructor(title, author, length) {
			super(title, author);
			if (length <= 0) {
				throw "Invalid length";
			}
			this.length = length;
		}

		play() {
			let result = super.play();
			result += ` - [${this.length}]`;
			return result;
		}
	}

	class Video extends Playable {
		constructor(title, author, imdbRating) {
			super(title, author);
			if (imdbRating < 1 || imdbRating > 5) {
				throw "Invalid IMDB rating";
			}
			this.imdbRating = imdbRating;
		}

		play() {
			let result = super.play();
			result += ` - [${this.imdbRating}]`;
			return result;
		}
	}

	const module = {
		getPlayer: function (name) {
			// returns a new Player instance with the provided name
			return new Player(name);
		},
		getPlaylist: function (name) {
			//returns a new playlist instance with the provided name
			return new PlayList(name);
		},
		getAudio: function (title, author, length) {
			//returns a new audio instance with the provided title, author and length
			return new Audio(title, author, length);
		},
		getVideo: function (title, author, imdbRating) {
			//returns a new video instance with the provided title, author and imdbRating
			return new Video(title, author, imdbRating);
		}
	};

	return module;
}

module.exports = solve;

// const {
// 	getPlayer,
// 	getPlaylist,
// 	getAudio,
// 	getVideo
// } = solve();

// //let testPlayer = getPlayer("playerName");
// let testPlaylist = getPlaylist("playlistName");
// let testAudio = getAudio("audioName", "author", 5);
// testPlaylist.addPlayable(testAudio);
// //testPlaylist.removePlayable(testAudio);
// for (let i = 0; i < 35; i += 1) {
// 	testPlaylist.addPlayable({
// 		id: (i + 1),
// 		title: 'Rock' + (9 - (i % 10))
// 	});
// }
// testPlaylist.listPlayables(2, 10)
// //let testVideo = getVideo("vid", "auth", 2);
// console.log("*");