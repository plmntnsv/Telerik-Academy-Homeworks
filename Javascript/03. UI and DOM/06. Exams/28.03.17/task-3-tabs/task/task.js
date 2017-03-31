function solve() {
	 var template = [
		'<div class="tabs-control">',
			'<ul class="list list-titles">',
			'{{#titles}}',
				'<li class="list-item">',
					'<label for="{{link}}" class="title">{{text}}</label>',
				'</li>',
			'{{/titles}}',
			'</ul>',
			'<ul class="list list-contents">',
				'{{#contents}}',
				'<li class="list-item">',
					'{{#if @index}}',
					'<input class="tab-content-toggle" id="{{link}}" name="tab-toggles" checked="checked/" type="radio">',
					'{{else}}',
					'<input class="tab-content-toggle" id="{{link}}" name="tab-toggles" type="radio">',					
					'{{/if}}',
					'<div class="content">{{{text}}}</div>',
				'</li>',
				'{{/contents}}',
			'</ul>',
		'</div>'
	].join('\n');
	return template;
}

if (typeof module !== 'undefined') {
	module.exports = solve;
}